using MMT.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace MMT.Domain.Interfaces
{
    public interface ICustomerEntityHandler
    {
        public Task<Customer> GetUserDetails(string email, CancellationToken ct = default);
        public Task<CustomerOrder> GetOrderDetail(Customer customer, CancellationToken ct = default);
    }
}