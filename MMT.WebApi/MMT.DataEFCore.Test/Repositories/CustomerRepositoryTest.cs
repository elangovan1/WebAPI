using MMT.DataEFCore.Repositories;
using MMT.Domain.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT.DataEFCore.Test.Repositories
{
    [TestFixture]
    public class CustomerRepositoryTest : TestBase
    {
        [Test]
        public async Task WhenGetIsCalledWithValidInput_ThenShoudReturnValidCustomerDetails()
        {
            var customer = new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232", WebSite = true, FirstName = "Bob", LastName = "Testperson", LastLoggedIn = DateTime.Now, HouseNumber = "1a", Street = "Uppingham Gate", Town = "Uppingham", PostCode = "LE15 9NY", PreferredLanuage = "en-gb" };
            dbContext.Customers.Add(customer);
            customer = new CustomerModel { Email = "test@test.com", Id = "Test1234", WebSite = true, FirstName = "Test", LastName = "Test", LastLoggedIn = DateTime.Now, HouseNumber = "1a", Street = "Uppingham Gate", Town = "Uppingham", PostCode = "LE15 9NY", PreferredLanuage = "en-gb" };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            var repo = new CustomerRepositoryModel(dbContext);
            var result = repo.GetUserDetails("bob@mmtdigital.co.uk");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Email, "bob@mmtdigital.co.uk");
            Assert.AreEqual(result.Id, "R223232");
            Assert.AreEqual(result.WebSite, true);
            Assert.AreEqual(result.FirstName, "Bob");
            Assert.AreEqual(result.LastName, "Testperson");
            Assert.AreEqual(result.LastLoggedIn.Date, customer.LastLoggedIn.Date);
            Assert.AreEqual(result.HouseNumber, "1a");
            Assert.AreEqual(result.Street, "Uppingham Gate");
            Assert.AreEqual(result.Town, "Uppingham");
            Assert.AreEqual(result.PostCode, "LE15 9NY");
            Assert.AreEqual(result.PreferredLanuage, "en-gb");
        }

        [Test]
        public async Task WhenGetOrderDetailIsCalledWithValidInput_ThenShoudReturnValidCustomerOrderDetails()
        {                             
            var customer = new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232", WebSite = true, FirstName = "Bob", LastName = "Testperson", LastLoggedIn = DateTime.Now, HouseNumber = "1a", Street = "Uppingham Gate", Town = "Uppingham", PostCode = "LE15 9NY", PreferredLanuage = "en-gb" };

            var product1 = new ProductModel
            {
                Id = 1,
                Name = "Tennis Ball"
            };

            var product2 = new ProductModel{
                    Id = 2,
                    Name = "Tennis Net"                 
             };

            var order = new OrderModel
            {
                Id =  456,
                OrderDate = DateTime.Now,
                CustomerId = customer.Id
            };


            var orderItem1 = new OrderItemModel
            {
                ProductId = 1,
                Quantity = 10,
                Price = 2.99m,
                OrderId = order.Id
            };

            var orderItem2 = new OrderItemModel
            {
                ProductId = 2,
                Quantity = 1,
                Price = 10.50m,
                OrderId = order.Id
            };
            
            dbContext.Customers.Add(customer);
            dbContext.Products.Add(product1);
            dbContext.Products.Add(product2);
            dbContext.Orders.Add(order);
            dbContext.OrderItems.Add(orderItem1);
            dbContext.OrderItems.Add(orderItem2);
            dbContext.SaveChanges();

            var repo = new CustomerRepositoryModel(dbContext);
            var result = repo.GetOrderDetail(new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232" });

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, "Bob");
            Assert.AreEqual(result.LastName, "Testperson");
            Assert.IsInstanceOf(typeof(OrderModel), result.Order);
            Assert.IsNotNull(result.Order);
            Assert.IsInstanceOf(typeof(List<OrderItemModel>), result.OrderItems);
            Assert.IsNotNull(result.OrderItems);
        }

        [Test]
        public async Task WhenGetOrderDetailIsCalledAnd_DBhasEmptyOrder_ThenShoudReturnNullOrderDetails()
        {
            var customer = new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232", WebSite = true, FirstName = "Bob", LastName = "Testperson", LastLoggedIn = DateTime.Now, HouseNumber = "1a", Street = "Uppingham Gate", Town = "Uppingham", PostCode = "LE15 9NY", PreferredLanuage = "en-gb" };

            var product1 = new ProductModel
            {
                Id = 1,
                Name = "Tennis Ball"
            };

            var product2 = new ProductModel
            {
                Id = 2,
                Name = "Tennis Net"
            };

            var order = new OrderModel();
            var orderItem1 = new OrderItemModel();
            var orderItem2 = new OrderItemModel();
            
            dbContext.Customers.Add(customer);
            dbContext.Products.Add(product1);
            dbContext.Products.Add(product2);
            dbContext.Orders.Add(order);
            dbContext.OrderItems.Add(orderItem1);
            dbContext.OrderItems.Add(orderItem2);
            dbContext.SaveChanges();

            var repo = new CustomerRepositoryModel(dbContext);
            var result = repo.GetOrderDetail(new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232" });

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, "Bob");
            Assert.AreEqual(result.LastName, "Testperson");            
            Assert.AreEqual(result.Order, null);            
            Assert.IsFalse(result.OrderItems.Any());
        }

        [Test]
        public async Task WhenGetOrderDetailIsCalledWithInvalidCustomerId_ThenShoudReturnNullOrderDetails()
        {
            var customer = new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232", WebSite = true, FirstName = "Bob", LastName = "Testperson", LastLoggedIn = DateTime.Now, HouseNumber = "1a", Street = "Uppingham Gate", Town = "Uppingham", PostCode = "LE15 9NY", PreferredLanuage = "en-gb" };

            var product1 = new ProductModel
            {
                Id = 1,
                Name = "Tennis Ball"
            };

            var product2 = new ProductModel
            {
                Id = 2,
                Name = "Tennis Net"
            };

            var order = new OrderModel();
            var orderItem1 = new OrderItemModel();
            var orderItem2 = new OrderItemModel();

            dbContext.Customers.Add(customer);
            dbContext.Products.Add(product1);
            dbContext.Products.Add(product2);
            dbContext.Orders.Add(order);
            dbContext.OrderItems.Add(orderItem1);
            dbContext.OrderItems.Add(orderItem2);
            dbContext.SaveChanges();

            var repo =  new CustomerRepositoryModel(dbContext);
            var result = repo.GetOrderDetail(new CustomerModel { Email = "fake@mmtdigital.co.uk",  Id = "R223232" });

            Assert.IsNull(result);            
        }
    }
}
