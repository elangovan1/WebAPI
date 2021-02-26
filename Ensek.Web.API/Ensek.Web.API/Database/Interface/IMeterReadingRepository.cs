using Ensek.Web.API.Entity;
using System.Collections.Generic;

namespace Ensek.Web.API.Database
{
    public interface IMeterReadingRepository
    {
        public IEnumerable<Account> GetAll();
    }
}