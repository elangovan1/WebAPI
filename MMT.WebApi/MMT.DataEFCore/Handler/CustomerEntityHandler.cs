
using MMT.Domain.Entity;
using MMT.Domain.Interface;
using MMT.Domain.Interfaces;
using MMT.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace MMT.DataEFCore.Handler
{
    public class CustomerEntityHandler : ICustomerEntityHandler
    {
        private readonly ICustomerRepositoryModel _customer;
            
        public CustomerEntityHandler(ICustomerRepositoryModel customer)
        {
            _customer = customer;
        }

        public Customer GetUserDetails(string email)
        {
            var result = _customer.GetUserDetails(email);   

            if(result == null)
            {
                return null;
            }
            
            return new Customer
            { 
                User = result.Email,
                CustomerId = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,  
                HouseNumber = result.HouseNumber,
                PostCode = result.PostCode,
                Street = result.Street,
                Town = result.Town,
                WebSite = result.WebSite,
                LastLoggedIn = result.LastLoggedIn,
                PreferredLanuage = result.PreferredLanuage
            };
        }

        public CustomerOrder GetOrderDetail(CustomerBase customer)
        {
            var custModel = new CustomerModel();
            custModel.Email = customer.User;
            custModel.Id = customer.CustomerId;

            var result = _customer.GetOrderDetail(custModel);

            if (result == null)
            {
                return null;
            }

            var customerOrder = new CustomerOrder
            {
                FirstName = result.FirstName,
                LastName = result.LastName
            };

            if (result.OrderItems.Any())
            {
                customerOrder.Order = new OrderDetails
                {
                    OrderNumber = result.Order?.Id,
                    OrderDate = result.Order?.OrderDate,
                    DeliveryExpected = result.Order?.DeliveryExpected,
                    Address = new Address
                    {
                        HouseNumber = result.HouseNumber,
                        PostCode = result.PostCode,
                        Street = result.Street,
                        Town = result.Town,
                    }
                };

                customerOrder.Order.OrderItems = new List<OrderItem>();
                foreach (var item in result.OrderItems)
                {
                    var pName = result.Product.FirstOrDefault(prod => prod.Id == item.ProductId);
                    customerOrder.Order.OrderItems.Add(
                        new OrderItem
                        {
                            ProductName = result.Order.ContainsGift ? "Gift" : result.Product.FirstOrDefault(prod => prod.Id == item.ProductId).Name,
                            PriceEach = item.Price,
                            Quantity = item.Quantity
                        });
                }
            }           

            return customerOrder;
        }
    }
}
