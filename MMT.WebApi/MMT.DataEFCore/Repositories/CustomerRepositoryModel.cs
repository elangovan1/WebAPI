using MMT.DataEFCore.DBContext;
using System.Linq;
using MMT.Utility;
using MMT.Domain.Model;
using MMT.Domain.Interface;
using System.Collections.Generic;

namespace MMT.DataEFCore.Repositories
{
    public class CustomerRepositoryModel : ICustomerRepositoryModel
    {
        private readonly DatabaseContext _context;

        public CustomerRepositoryModel(DatabaseContext dbContext)
        {
            Ensure.IsNotNull(dbContext, nameof(dbContext));

            _context = dbContext;
        }
        public CustomerModel GetUserDetails(string email)
        {
            var result = _context.Customers.Where(m => m.Email == email);

            if (!result.Any())
            {
                return null;
            }

            return result.FirstOrDefault();
        }
        public CustomerOrderModel GetOrderDetail(CustomerModel customer)
        {
            var result = new CustomerOrderModel();
            var cust = _context.Customers.FirstOrDefault(cust => cust.Id == customer.Id);

            if (cust?.Email != customer.Email)
            {
                return null;
            }
            IEnumerable<OrderItemModel> orderItems = new List<OrderItemModel>();
            IEnumerable<ProductModel> product = new List<ProductModel>();

            var order = _context.Orders.OrderByDescending(item => item.OrderDate).FirstOrDefault(m => m.CustomerId == customer.Id);

            if (order != null)
            {
                orderItems = _context.OrderItems.AsEnumerable().Where(orderItem => orderItem.OrderId == order.Id).ToList();
                product = _context.Products.AsEnumerable().Where(prod => orderItems.Any(oitem => prod.Id == oitem.ProductId)).ToList();
            }

            result = new CustomerOrderModel
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                HouseNumber = cust.HouseNumber,
                PostCode = cust.PostCode,
                Street = cust.Street,
                Town = cust.Town,
                Order = order,
                OrderItems = orderItems.Any() ? orderItems.ToList() : new List<OrderItemModel>(),
                Product = orderItems.Any() ?  product.ToList() : new List<ProductModel>()
            };

            return result;
        }
    }
}
