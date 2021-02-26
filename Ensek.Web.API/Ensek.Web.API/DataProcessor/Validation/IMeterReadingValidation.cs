using Ensek.Web.API.Entity;
using System.Collections.Generic;

namespace Ensek.Web.API.DataProcessor
{
    public interface IMeterReadingValidation
    {
        //public bool IsDuplicateAccount(int accountNumber);
        //public bool IsValidReading(string accountNumber);
        //public bool IsAccountExist(int accountNumber);
        //public bool IsRedingAssociatedWithAccount(int accountNumber);
        public IEnumerable<StatusReport> ValidateAll();
    }
}
