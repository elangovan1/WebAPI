using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MMT.Domain.Entity;
using MMT.Domain.Interfaces;
using MMT.Utility;
using System;
using System.Threading.Tasks;

namespace MMT.WebApi.Controllers
{

    [Route("api/GetUserDetails")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerEntityHandler _customerHandler;

        public CustomerController(ICustomerEntityHandler customerHandler)
        {
            _customerHandler = customerHandler;
        }

        [HttpPost]        
        public async Task<ActionResult<CustomerOrder>> GetOrderDetails(Customer customer)
        {
            try
            {
                Ensure.IsNotNull(customer, nameof(customer));
                Ensure.IsNullOrWhiteSpace(customer.Email, nameof(customer.Email));
                Ensure.IsNullOrWhiteSpace(customer.Id, nameof(customer.Id));

                var result = await _customerHandler.GetOrderDetail(customer);
                               
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetUserDetails(string email)
        {
            try
            {
                Ensure.IsNullOrWhiteSpace(email, nameof(email));

                var result = await _customerHandler.GetUserDetails(email);
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
    }
}
