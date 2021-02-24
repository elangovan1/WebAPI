using MMT.Domain.Model;

namespace MMT.Domain.Interface
{
    public interface ICustomerRepositoryModel
    {
        public CustomerModel GetUserDetails(string email);
        public CustomerOrderModel GetOrderDetail(CustomerModel customer);
    }
}
