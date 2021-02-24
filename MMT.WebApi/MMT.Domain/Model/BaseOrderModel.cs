using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Domain.Model
{
    public class BaseOrderModel
    {
        [Key]
        [Column("ORDERID")]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
    }
}