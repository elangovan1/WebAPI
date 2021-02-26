using Ensek.Web.API.Database;
using Ensek.Web.API.DataProvider;
using Ensek.Web.API.Entity;
using Ensek.Web.API.Reader;
using System.Collections.Generic;
using System.Linq;

namespace Ensek.Web.API.DataProcessor
{
    public class MeterReadingProcessor
    {
        private readonly IMeterReadingUploadRepository _meterReadingUploadRepository;
        private readonly IMeterReadingRepository _meterReadingRepository;
       

        public MeterReadingProcessor(IMeterReadingUploadRepository meterReadingRepository, IMeterReadingRepository accountRepository)
        {
            _meterReadingRepository = accountRepository;
            _meterReadingUploadRepository = meterReadingRepository;
        }
    public IEnumerable<StatusReport> GetData(string fileName)
        {            
            var excelReader = new ExcelReader();
            var reading = excelReader.Reader(fileName);
            var accounts = _meterReadingRepository.GetAll();
            var alreadyUploaded = _meterReadingUploadRepository.GetAll();

            var meterReadingValidation = new MeterReadingValidation(reading, accounts, _meterReadingUploadRepository);
            IEnumerable<StatusReport> report = meterReadingValidation.ValidateAll();
         
            if (report.Any(m => m.IsValid))
            {
                List<MeterReading> meterReadings = new List<MeterReading>();

                meterReadings = new List<MeterReading>();
                foreach (var item in report.Where(m => m.IsValid))
                {
                    meterReadings.Add(new MeterReading
                    {
                        AccountId = item.AccountId,
                        Value = item.MeterReading,
                        NotedOn = item.NotedOn
                    });
                }
                _meterReadingUploadRepository.InsertAll(meterReadings); 
            }
            
            return report;
        }        
    }
}
