using MMT.Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace MMT.Domain.Interface
{
    public interface ICustomerModelHandler
    {
        public Task<CustomerModel> GetUserDetails(string email, CancellationToken ct = default);
        public Task<CustomerOrderModel> GetOrderDetail(CustomerModel customer, CancellationToken ct = default);
    }
}
