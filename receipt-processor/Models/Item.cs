namespace receipt_processor.Models
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string shortDescription { get; set; }
        public string price { get; set; }
    }
}