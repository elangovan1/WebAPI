using MMT.Domain.Entity;
using MMT.Domain.Interfaces;
using MMT.WebApi.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MMT.WebApi.Test
{
    public class CustomerControllerTest
    {
        [Test]
        public async Task CustomerController_GetUserDetails_Returns_ValidResponse()
        {
            var customer = new Customer { User = "bob@mmtdigital.co.uk", CustomerId = "R223232", WebSite = true, FirstName = "Bob", LastName = "Testperson", LastLoggedIn = DateTime.Now, HouseNumber = "1a", Street = "Uppingham Gate", Town = "Uppingham", PostCode = "LE15 9NY", PreferredLanuage = "en-gb" };

            var customerEntityHandler = new Mock<ICustomerEntityHandler>();
            var customerController = new CustomerController(customerEntityHandler.Object);
            customerEntityHandler.Setup(x => x.GetUserDetails(customer.User)).Returns(customer);
            var result = customerController.GetUserDetails(customer.User);

            Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
            var status = result.Result as OkObjectResult;
            Assert.AreEqual(200, status.StatusCode);
            Assert.IsInstanceOf(typeof(Customer), status.Value);            
            customerEntityHandler.Verify(x => x.GetUserDetails(It.IsAny<string>()), Times.Once);
        }
        [Test]
        public async Task CustomerController_GetOrderDetails_Returns_ValidResponse()
        {
            var customer = new CustomerBase { User = "bob@mmtdigital.co.uk", CustomerId = "R223232" };

            var customerEntityHandler = new Mock<ICustomerEntityHandler>();
            var customerController = new CustomerController(customerEntityHandler.Object);
            customerEntityHandler.Setup(x => x.GetOrderDetail(customer)).Returns(new CustomerOrder {
            Order = new OrderDetails()
            });
            var result = customerController.GetOrderDetails(customer);

            Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
            var status = result.Result as OkObjectResult;
            Assert.AreEqual(200, status.StatusCode);
            Assert.IsInstanceOf(typeof(CustomerOrder), status.Value);
            customerEntityHandler.Verify(x => x.GetOrderDetail(customer), Times.Once);
        }
    }
}
