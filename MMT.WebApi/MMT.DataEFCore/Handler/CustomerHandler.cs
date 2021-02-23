
using MMT.Domain.Entity;
using MMT.Domain.Interface;
using MMT.Domain.Interfaces;
using MMT.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MMT.DataEFCore.Handler
{
    public class CustomerHandler : ICustomerEntityHandler
    {
        private readonly ICustomerModelHandler _customer;

        public CustomerHandler(ICustomerModelHandler customer)
        {
            _customer = customer;
        }

        public async Task<Customer> GetUserDetails(string email, CancellationToken ct = default)
        {
            var result = await _customer.GetUserDetails(email, ct);   
            
            return new Customer
            { 
                Email = result.Email,
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,  
                HouseNumber = result.HouseNumber,
                PostCode = result.PostCode,
                Street = result.Street,
                Town = result.Town
            };
        }

        public async Task<CustomerOrder> GetOrderDetail(Customer customer, CancellationToken ct = default)
        {
            var custModel = new CustomerModel();
            custModel.Email = customer.Email;
            custModel.Id = customer.Id;

            var result = await _customer.GetOrderDetail(custModel, ct);

            var customerOrder = new CustomerOrder
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                Order = new CustomerOrderDetails()
                {
                    OrderNumber = result.Order.Id,
                    OrderDate = result.Order.OrderDate,
                    Address = new Address
                    {
                        HouseNumber = result.HouseNumber,
                        PostCode = result.PostCode,
                        Street= result.Street,
                        Town = result.Town,
                    }
                }
            };

            if (result.OrderItems.Any())
            {
                customerOrder.Order.OrderItems = new List<OrderItem>();
                foreach (var item in result.OrderItems)
                {
                    customerOrder.Order.OrderItems.Add(
                        new OrderItem
                        {
                            ProductName = result.Product.FirstOrDefault(prod=>prod.Id == item.Id).Name.Replace("gift", "Gift"),
                            PriceEach = item.Price,
                            Quantity= item.Quantity
                        });
                }
            }

            return customerOrder;
        }
    }
}
