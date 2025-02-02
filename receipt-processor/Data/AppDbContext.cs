using Microsoft.EntityFrameworkCore;
using receipt_processor.Models;

namespace receipt_processor.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Receipt> Receipt { get; set; }
    }
}
