using System;
using System.Collections.Generic;

namespace MMT.Domain.Entity
{
    public class CustomerOrder
    {
        public CustomerOrderDetails Order { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CustomerOrderDetails 
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Address Address { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
