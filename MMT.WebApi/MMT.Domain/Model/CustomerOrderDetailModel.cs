using System.Collections.Generic;

namespace MMT.Domain.Model
{
    public class CustomerOrderDetailModel
    {
        public IEnumerable<OrderItemModel> OrderItems { get; set; }
        public AddressModel Address { get; set; }
    }
}