namespace TrafficBackendAPI.DatabaseModule.Models.UserModule
{
    public class AddressModel : BaseModel
    {
        public string? LotNo { get; set; }

        public required string Street { get; set; }

        public required string Barangay { get; set; }

        public required string City { get; set; }

        public required string Region { get; set; }

        public required string Country { get; set; }

        public int PostalCode { get; set; }

        public Guid UserId { get; set; }

        public virtual required UserModel User { get; set; }
    }
}
