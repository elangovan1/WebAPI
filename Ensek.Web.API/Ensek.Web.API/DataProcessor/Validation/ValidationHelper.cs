using Ensek.Web.API.Entity;
using Ensek.Web.API.Utility;
using System.Collections.Generic;
using System.Linq;

namespace Ensek.Web.API.DataProcessor
{
    public class ValidationHelper : IValidationHelper
    {
        private readonly IEnumerable<MeterReading> _input;
        private readonly IEnumerable<Account> _account;
        public ValidationHelper(IEnumerable<MeterReading> input, IEnumerable<Account> account)
        {
            _input = input;
            _account = account;
        }
        public bool IsDuplicateAccount(int accountNumber)
        {
            return _input.Count(reading => reading.AccountId == accountNumber) >= 2;
        }

        public bool IsAccountExist(int accountNumber)
        {
            return _account.Any(acc => acc.AccountId == accountNumber);
        }

        public bool IsValidReading(string accountNumber)
        {
            return accountNumber.IsDigit() && accountNumber.Length <= 5 && accountNumber.Length >= 1;
        }
    }
}
