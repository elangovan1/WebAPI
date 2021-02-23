using MMT.DataEFCore.DBContext;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MMT.Utility;
using MMT.Domain.Model;
using MMT.Domain.Interface;

namespace MMT.DataEFCore.Repositories
{
    public class CustomerRepository : ICustomerModelHandler
    {
        private readonly DatabaseContext _context;

        public CustomerRepository(DatabaseContext dbContext)
        {
            Ensure.IsNotNull(dbContext, nameof(dbContext));

            _context = dbContext;
        }
        public async Task<CustomerModel> GetUserDetails(string email, CancellationToken ct = default)
        {
            var result = _context.Customers.Where(m => m.Email == email);
            return await result.FirstOrDefaultAsync();
        }
        public async Task<CustomerOrderModel> GetOrderDetail(CustomerModel customer, CancellationToken ct = default)
        {
            var result = new CustomerOrderModel();
            var cust = _context.Customers.FirstOrDefaultAsync(m => m.Id == customer.Id).Result;
            var order = _context.Orders.FirstOrDefaultAsync(m => m.CustomerId == customer.Id).Result;
            var orderItems = _context.OrderItems.Where(m => m.OrderId == order.Id);
            var product = _context.Products.Where(prod => orderItems.Any(oitem => prod.Id == oitem.ProductId));

            result = new CustomerOrderModel
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Order = order,
                OrderItems = orderItems.ToList(),
                Product = product.ToList()
            };

            return result;
        }
    }
}
