namespace ShoppingStore.Models
{
    public class OrderItem
    {

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Number { get; set; }
    }
}
