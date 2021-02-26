using Ensek.Web.API.Database;
using Ensek.Web.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ensek.Web.API.DataProvider
{
    public class MeterReadingUploadRepository : IMeterReadingUploadRepository
    {
        private readonly DatabaseContext _context;

        public MeterReadingUploadRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public bool Delete(int id)
        {
            var result = false;
            var toRemove = _context.MeterReading.First(reading=>reading.AccountId == id);
            if (toRemove != null)
            {
                _context.MeterReading.Remove(toRemove);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public IEnumerable<MeterReading> GetAll()
        {
            var result = _context.MeterReading.ToList();
            return result;
        }

        public MeterReading GetById(int id)
        {
            return _context.MeterReading.FirstOrDefault(m => m.AccountId == id); 
        }

        public MeterReading Insert(MeterReading meterReading)
        {
            _context.MeterReading.Add(meterReading);
            _context.SaveChanges();
            return meterReading;
        }

        public List<MeterReading> InsertAll(List<MeterReading> meterReadings)
        {
            foreach (var item in meterReadings)
            {
                _context.MeterReading.Add(item);
            }
            _context.SaveChanges();
            return _context.MeterReading.ToList();
        }

        public bool Update(MeterReading input)
        {
            var result = false;
            if (IsAccountExists(input.AccountId))
            {
                _context.MeterReading.Update(input);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        private bool IsAccountExists(int id) =>  _context.MeterReading.Any(a => a.AccountId == id);

        public bool IsMeterReadingExists(int accountId, DateTime notedOn, string value) => 
            _context.MeterReading.Any(a => a.AccountId == accountId && a.NotedOn == notedOn && a.Value == value);
    }
}
