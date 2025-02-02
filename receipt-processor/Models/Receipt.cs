namespace receipt_processor.Models
{
    public class Receipt
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string retailer { get; set; }
        public string purchaseDate { get; set; }
        public string purchaseTime { get; set; }
        public string total { get; set; }
        public List<Item> items { get; set; }
    }
}
