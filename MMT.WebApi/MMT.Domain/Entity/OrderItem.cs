namespace MMT.Domain.Entity
{
    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }        
    }
}