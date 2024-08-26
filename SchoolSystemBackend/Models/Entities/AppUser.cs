using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemBackend.Models.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderType
    {
        Male,
        Female,
        Other
    }
    public abstract class AppUser
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public ICollection<NextOfKin> NextOfKins { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

    }
}
