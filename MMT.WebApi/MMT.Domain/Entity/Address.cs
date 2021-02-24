namespace MMT.Domain.Entity
{
    public class Address : CustomerBase
    {
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}