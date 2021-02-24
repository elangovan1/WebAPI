using MMT.DataEFCore.Handler;
using MMT.DataEFCore.Test.Repositories;
using MMT.Domain.Entity;
using MMT.Domain.Interface;
using MMT.Domain.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MMT.DataEFCore.Test.Handler
{
    public class CustomerHandlerTest : TestBase
    {
        [Test]
        public void CustomerHandler_Get_Returns_Customer_When_InputIsValid()
        {
            var customer = new CustomerModel { Email = "bob@mmtdigital.co.uk", Id = "R223232",  FirstName = "Bob", LastName = "Testperson" };

            var customerRepository = new Mock<ICustomerRepositoryModel>();
            var customerHandler = new CustomerEntityHandler(customerRepository.Object);
            customerRepository.Setup(x => x.GetUserDetails(It.IsAny<string>())).Returns(customer);

            var result = customerHandler.GetUserDetails("FakeEmailAddress");

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(CustomerBase), result);
        }

        [Test]
        public void CustomerHandler_GetOrderDetail_Returns_Customer_When_InputIsValid()
        {
            var customer = new Customer { User = "bob@mmtdigital.co.uk", CustomerId = "R223232",  FirstName = "Bob", LastName = "Testperson" };
            var customerRepository = new Mock<ICustomerRepositoryModel>();
            var customerHandler = new CustomerEntityHandler(customerRepository.Object);


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

            customerRepository.Setup(x => x.GetOrderDetail(It.IsAny<CustomerModel>())).Returns(customerModel);

            var result = customerHandler.GetOrderDetail(customer);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(CustomerOrder), result);
        }
    }
}
