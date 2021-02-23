using MMT.DataEFCore.Handler;
using MMT.DataEFCore.Test.Repositories;
using MMT.Domain.Entity;
using MMT.Domain.Interface;
using MMT.Domain.Interfaces;
using MMT.Domain.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMT.DataEFCore.Test.Handler
{
    public class CustomerHandlerTest : TestBase
    {
        [Test]
        public void CustomerHandler_Get_Returns_Customer_When_InputIsValid()
        {
            var customer = new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232",  FirstName = "Bob", LastName = "Testperson" };

            var customerRepository = new Mock<ICustomerModelHandler>();
            var customerHandler = new CustomerHandler(customerRepository.Object);
            customerRepository.Setup(x => x.GetUserDetails(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(customer));

            var result = customerHandler.GetUserDetails("FakeEmailAddress").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(Customer), result);
        }

        [Test]
        public void CustomerHandler_GetOrderDetail_Returns_Customer_When_InputIsValid()
        {
            var customer = new Customer { Email = "bob@mmtdigital.co.uk", Id = "R223232",  FirstName = "Bob", LastName = "Testperson" };
            var customerRepository = new Mock<ICustomerModelHandler>();
            var customerHandler = new CustomerHandler(customerRepository.Object);


            var customerModel = new CustomerOrderModel()
            {
                FirstName = "FirstName",
                HouseNumber = "HouseNumber",
                LastName = "LastName",
                PostCode = "PostCode",
                Street = "Street",
                Town = "Town",
                Order = new OrderModel(),
                OrderItems = new List<OrderItemModel>(),
                Product = new List<ProductModel>()
            };

            customerRepository.Setup(x => x.GetOrderDetail(It.IsAny<CustomerModel>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(customerModel));

            var result = customerHandler.GetOrderDetail(customer).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(CustomerOrderDetails), result.Order);
        }
    }
}
