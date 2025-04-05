using System.ComponentModel.DataAnnotations;

namespace TrafficBackendAPI.Models.Users
{
    public class UpdateUserModel
    {
        [Required(ErrorMessage = "This is a required field")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public bool IsAnonymous { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public Guid UpdatedBy { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public DateTime DateUpdated { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public bool IsActive { get; set; }
    }
}
