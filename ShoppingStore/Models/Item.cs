namespace ShoppingStore.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Original { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public string Seller { get; set; }
        public bool NewTag { get; set; }

        public Item()
        {
        }
    }
}
