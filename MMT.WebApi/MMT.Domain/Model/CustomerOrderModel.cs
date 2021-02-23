using System.Collections.Generic;
using System.Linq;

namespace MMT.Domain.Model
{
    public class CustomerOrderModel : AddressModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public OrderModel Order { get; set; }
        public IList<OrderItemModel> OrderItems { get; set; }
        public IList<ProductModel> Product { get; set; }
    }
}
