using Ensek.Web.API.DataProvider;
using Ensek.Web.API.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Ensek.Web.API.DataProcessor
{
    public class MeterReadingValidation : IMeterReadingValidation
    {
        private readonly IEnumerable<MeterReading> _input;
        private readonly IEnumerable<Account> _account;
        private readonly ValidationHelper _validationHelper;
        private readonly IMeterReadingUploadRepository _meterReadingUploadRepository;

        public MeterReadingValidation(IEnumerable<MeterReading> input, IEnumerable<Account> account, IMeterReadingUploadRepository meterReadingUploadRepository)
        {
            _input = input;
            _account = account;
            _validationHelper = new ValidationHelper(input, account);
            _meterReadingUploadRepository = meterReadingUploadRepository;
        }

        public IEnumerable<StatusReport> ValidateAll()
        {
            var reports = new List<StatusReport>();
            foreach (var input in _input)
            {
                var report = new StatusReport();
                report.AccountId = input.AccountId;
                report.IsValid = true;
                report.Message = "Success";
                report.MeterReading = input.Value;
                report.NotedOn = input.NotedOn;

                if (!_validationHelper.IsAccountExist(input.AccountId))
                {
                    report.IsValid = false;
                    report.Message = "Invalid Account / Reding is not associated with account";
                    reports.Add(report);
                    continue;
                }
                var accountData = _account.FirstOrDefault(m => m.AccountId == input.AccountId);
                report.FirstName = accountData.FirstName;
                report.LastName = accountData.LastName;                

                if (_validationHelper.IsDuplicateAccount(input.AccountId))
                {
                    report.IsValid = false;
                    report.Message = "Duplicate Account";
                }               
                if (!_validationHelper.IsValidReading(input.Value))
                {
                    report.IsValid = false;
                    report.Message = "Invalid Meter Reading";
                }
                if (_meterReadingUploadRepository.IsMeterReadingExists(input.AccountId, input.NotedOn, input.Value))
                {
                    report.IsValid = false;
                    report.Message = "Meter Reading alread updated";
                }
                reports.Add(report);
            }
            return reports;
        }

    }
}
