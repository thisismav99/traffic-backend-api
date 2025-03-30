namespace TrafficBackendAPI.Models.Users
{
    public class UserRequestModel
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public bool IsAnonymous { get; set; }

        public required Guid CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}
