namespace TrafficBackendAPI.UserModule.Models
{
    internal class UserModel : BaseModel
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public Guid AddressId { get; set; }

        public bool IsAnonymous { get; set; }

        public virtual required AddressModel AddressModel { get; set; }
    }
}
