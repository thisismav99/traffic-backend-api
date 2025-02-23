namespace TrafficBackendAPI.UserModule.Models
{
    internal class BaseModel
    {
        public Guid Id { get; set; }

        public required Guid CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}
