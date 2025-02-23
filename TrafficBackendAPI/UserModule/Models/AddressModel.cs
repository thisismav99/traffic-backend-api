namespace TrafficBackendAPI.UserModule.Models
{
    internal class AddressModel : BaseModel
    {
        public string? LotNo { get; set; }

        public required string Street { get; set; }

        public required string Barangay { get; set; }

        public required string City { get; set; }

        public required string Region { get; set; }

        public required string Country { get; set; }

        public int PostalCode { get; set; }
    }
}
