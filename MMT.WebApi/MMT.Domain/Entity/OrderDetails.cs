using System;
using System.Collections.Generic;

namespace MMT.Domain.Entity
{
    public class OrderDetails
    {
        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public Address Address { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public DateTime? DeliveryExpected { get; set; }
    }
}
