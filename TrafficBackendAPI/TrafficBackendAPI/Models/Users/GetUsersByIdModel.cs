using System.ComponentModel.DataAnnotations;

namespace TrafficBackendAPI.Models.Users
{
    public class GetUsersByIdModel
    {
        [Required(ErrorMessage = "This is a required field")]
        public required List<Guid> UsersId { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public bool AsNoTracking { get; set; }
    }
}
