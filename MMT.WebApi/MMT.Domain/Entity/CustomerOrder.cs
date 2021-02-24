namespace MMT.Domain.Entity
{
    public class CustomerOrder : Customer
    {
        public OrderDetails Order { get; set; }     
    }   
}
