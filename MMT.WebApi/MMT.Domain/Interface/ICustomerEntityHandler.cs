using MMT.Domain.Entity;

namespace MMT.Domain.Interfaces
{
    public interface ICustomerEntityHandler
    {
        public Customer GetUserDetails(string email);
        public CustomerOrder GetOrderDetail(CustomerBase customer);
    }
}