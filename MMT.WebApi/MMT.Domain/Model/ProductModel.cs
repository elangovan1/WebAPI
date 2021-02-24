using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Domain.Model
{
    public sealed class ProductModel
    {
        [Key]
        [Column("PRODUCTID")]
        public int Id { get; set; }
        [Column("PRODUCTNAME")]
        public string Name { get; set; }
        public decimal PackHeight { get; set; }
        public decimal PackWidth { get; set; }
        public decimal PackWeight { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
    }
}
