using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Domain.Model
{
    public sealed class OrderItemModel
    {
        [Key]
        [Column("ORDERITEMID")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Returnable { get; set; }
    }
}
