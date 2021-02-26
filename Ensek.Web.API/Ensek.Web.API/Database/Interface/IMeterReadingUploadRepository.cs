using Ensek.Web.API.Entity;
using System;
using System.Collections.Generic;

namespace Ensek.Web.API.DataProvider
{
    public interface IMeterReadingUploadRepository
    {
        public IEnumerable<MeterReading> GetAll();
        public MeterReading GetById(int id);
        public MeterReading Insert(MeterReading meterReading);
        public List<MeterReading> InsertAll(List<MeterReading> meterReading);
        public bool Update(MeterReading meterReading);
        public bool Delete(int id);
        public bool IsMeterReadingExists(int accountId, DateTime notedOn, string value);
    }
}
