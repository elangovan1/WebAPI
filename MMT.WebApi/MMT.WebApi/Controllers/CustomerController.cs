using Microsoft.AspNetCore.Mvc;
using MMT.Domain.Entity;
using MMT.Domain.Interfaces;
using MMT.Utility;
using System;

namespace MMT.WebApi.Controllers
{

    [Route("api/{actionname}")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerEntityHandler _customerHandler;

        public CustomerController(ICustomerEntityHandler customerHandler)
        {
            _customerHandler = customerHandler;
        }

        [HttpGet]
        public ActionResult<CustomerOrder> GetUserDetails(string email)
        {
            try
            {
                Ensure.IsNullOrWhiteSpace(email, nameof(email));

                var result = _customerHandler.GetUserDetails(email);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public  ActionResult<CustomerOrder> GetOrderDetails([FromBody]CustomerBase customer)
        {
            try
            {
                Ensure.IsNotNull(customer, nameof(customer));
                Ensure.IsNullOrWhiteSpace(customer.User, nameof(customer.User));
                Ensure.IsNullOrWhiteSpace(customer.CustomerId, nameof(customer.CustomerId));

                var result = _customerHandler.GetOrderDetail(customer);

                if (result == null)
                {
                    return BadRequest();
                }
                if (result.Order == null)
                {
                    return GetUserDetails(customer.User);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
