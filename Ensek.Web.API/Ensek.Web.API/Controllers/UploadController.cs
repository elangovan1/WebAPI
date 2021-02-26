using Ensek.Web.API.Database;
using Ensek.Web.API.DataProcessor;
using Ensek.Web.API.DataProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace Ensek.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMeterReadingUploadRepository _meterReadingRepository;
        private readonly IMeterReadingRepository _accountRepository;
        public UploadController(IMeterReadingUploadRepository meterReadingRepository, IMeterReadingRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _meterReadingRepository = meterReadingRepository;
        }

        [HttpPost("meter-reading-uploads", Name = "meter-reading-uploads")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]       
        public IActionResult UploadFile(IFormFile file, CancellationToken cancellationToken)
        {

            try
            {
                var fileName = FileHelper.WriteFile(file);
                var meterReadingProcessor = new MeterReadingProcessor(_meterReadingRepository, _accountRepository);
                var result = meterReadingProcessor.GetData(fileName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
       
    }
}
