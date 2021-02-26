using Ensek.Web.API.DataProcessor;
using Ensek.Web.API.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ensek.Web.Api.Tests.DataProcessor
{
    public class validationHelperTest
    {
        [Test]
        public void WhenIsDuplicate_IsCalledWithDuplicateData_ItShouldReturn_True()
        {
            var meterReadings = new List<MeterReading>();
            var account = new List<Account>();

            meterReadings.Add(
                new MeterReading
                {
                    AccountId = 1,
                    NotedOn = DateTime.Now,
                    Value = "123"
                });

            meterReadings.Add(new MeterReading
            {
                AccountId = 1,
                NotedOn = DateTime.Now,
                Value = "123"
            });
            
            var validationHelper = new ValidationHelper(meterReadings, account);

            var result = validationHelper.IsDuplicateAccount(1);
            Assert.IsTrue(result);
        }

        [Test]
        public void WhenIsDuplicate_IsCalledWithUniqueData_ItShouldReturn_False()
        {
            var meterReadings = new List<MeterReading>();
            var account = new List<Account>();

            meterReadings.Add(
                new MeterReading
                {
                    AccountId = 1,
                    NotedOn = DateTime.Now,
                    Value = "123"
                });

            meterReadings.Add(new MeterReading
            {
                AccountId = 2,
                NotedOn = DateTime.Now,
                Value = "123"
            });

            var validationHelper = new ValidationHelper(meterReadings, account);

            var result = validationHelper.IsDuplicateAccount(1);
            Assert.IsFalse(result);
        }

        [Test]
        public void WhenIsValidReading_IsCalledWithValidData_ItShouldReturn_True()
        {
            var meterReadings = new List<MeterReading>();
            var account = new List<Account>();
            var validationHelper = new ValidationHelper(meterReadings, account);
            var result = validationHelper.IsValidReading("1234");
            Assert.IsTrue(result);
        }
        [Test]
        [TestCase("")]
        [TestCase("123456")]
        [TestCase("Fake")]
        public void WhenIsValidReading_IsCalledWithValidData_ItShouldReturn_False(string value)
        {
            var meterReadings = new List<MeterReading>();
            var account = new List<Account>();

            var validationHelper = new ValidationHelper(meterReadings, account);
            var result = validationHelper.IsValidReading(value);
            Assert.IsFalse(result);
        }
    }
}
