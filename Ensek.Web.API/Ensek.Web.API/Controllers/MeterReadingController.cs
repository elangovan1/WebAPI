using Ensek.Web.API.DataProvider;
using Ensek.Web.API.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ensek.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingUploadRepository _meterReadingRepository;
        
        public MeterReadingController(IMeterReadingUploadRepository meterReadingRepository)
        {
            _meterReadingRepository = meterReadingRepository;            
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<MeterReading>))]
        public ActionResult<IEnumerable<MeterReading>> GetAll()
        {
            try
            {
                var result =  _meterReadingRepository.GetAll();
                if (!result.Any())
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

        [HttpGet("{id}")]
        [Produces(typeof(MeterReading))]
        public  ActionResult<MeterReading> GetById(int id)
        {
            try
            {
                var result = _meterReadingRepository.GetById(id);
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
        public  ActionResult<MeterReading> Post([FromBody] MeterReading input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return new OkObjectResult(_meterReadingRepository.Insert(input)) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<MeterReading> Put(int id, [FromBody] MeterReading input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                var result =  _meterReadingRepository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return StatusCode(201,  _meterReadingRepository.Update(input));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAsync(int id)
        {
            try
            {
                var result = _meterReadingRepository.Delete(id);
                if (!result)
                {
                    return StatusCode(500);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
