namespace TrafficBackendAPI.DatabaseModule.Models.UserModule
{
    public class ContactModel : BaseModel
    {
        public string? TelNo { get; set; }

        public required string Email { get; set; }

        public required string MobileNo { get; set; }

        public Guid UserId { get; set; }

        public virtual required UserModel User { get; set; }
    }
}
