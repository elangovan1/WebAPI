namespace Ensek.Web.API.DataProcessor
{
    public interface IValidationHelper
    {
        public bool IsDuplicateAccount(int accountNumber);
        public bool IsAccountExist(int accountNumber);
        public bool IsValidReading(string accountNumber);
    }
}