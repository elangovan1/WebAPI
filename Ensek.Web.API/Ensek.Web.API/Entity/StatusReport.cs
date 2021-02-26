using System;

namespace Ensek.Web.API.Entity
{
    public class StatusReport : Account
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public string MeterReading { get; set; }
        public DateTime NotedOn { get; set; }
    }
}