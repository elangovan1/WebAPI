namespace MMT.Domain.Model
{
    public sealed class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PackHeight { get; set; }
        public decimal PackWidth { get; set; }
        public decimal PackWeight { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
    }
}
