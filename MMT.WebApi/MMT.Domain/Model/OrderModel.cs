using System;

namespace MMT.Domain.Model
{
    public class OrderModel : BaseOrderModel
    {        
        public string CustomerId { get; set; }       
        public DateTime DeliveryExpected { get; set; }
        public bool ContainGift { get; set; }
        public string ShippingMode { get; set; }
        public string OrderSource { get; set; }
        //public virtual Customer Customer { get; set; } = new Customer();
    }
}
