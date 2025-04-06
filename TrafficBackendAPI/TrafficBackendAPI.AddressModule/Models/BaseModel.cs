namespace TrafficBackendAPI.UserAddressModule.Models
{
    internal class BaseModel
    {
        public Guid Id { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? DateUpdated { get; set; }

        public bool IsActive { get; set; }
    }
}
