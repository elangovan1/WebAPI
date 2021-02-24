using System;

namespace MMT.Domain.Model
{
    public class OrderModel : BaseOrderModel
    {        
        public string CustomerId { get; set; }       
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }
        public string ShippingMode { get; set; }
        public string OrderSource { get; set; }        
    }
}
