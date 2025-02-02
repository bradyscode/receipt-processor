using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using receipt_processor.Data;
using receipt_processor.Models;
using receipt_processor.Services;

namespace receipt_processor.Controllers
{
    [Route("receipts/")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceiptsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/points")]
        public async Task<ActionResult<int>> GetReceipt(Guid id)
        {
            var receipt = await _context.Receipt
                .Include(r => r.items)  
                .FirstOrDefaultAsync(r => r.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }
            var points = new ReceiptPointsCalculator().CalculatePoints(receipt);

            return Ok(new { points = points });
        }

        [HttpPost("process")]
        public async Task<ActionResult<Receipt>> PostReceipt(Receipt receipt)
        {
            _context.Receipt.Add(receipt);
            await _context.SaveChangesAsync();

            return Ok(new { id = receipt.Id });
        }
    }
}
