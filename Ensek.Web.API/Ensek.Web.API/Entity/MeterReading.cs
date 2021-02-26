using System;
using System.ComponentModel.DataAnnotations;

namespace Ensek.Web.API.Entity
{
    public class MeterReading 
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime NotedOn { get; set; }
        public string Value { get; set; }
        public Account Account { get; set; }
    }
}
