using Ensek.Web.API.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Ensek.Web.API.Database
{
    public class MeterReadingRepository : IMeterReadingRepository
    {
        private readonly DatabaseContext _context;

        public MeterReadingRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<Account> GetAll()
        {
            var result = _context.Account.ToList();
            return result;
        }
    }
}
