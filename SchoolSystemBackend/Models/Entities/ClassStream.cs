using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolSystemBackend.Models.Entities
{
    public class ClassStream
    {
        [Key]
        public Guid StreamId { get; set; }
        public required string StreamName { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public IEnumerable<Grade> Grades { get; set; } = new List<Grade>();
    }
}
