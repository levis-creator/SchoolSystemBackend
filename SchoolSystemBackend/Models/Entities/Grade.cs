using System.ComponentModel.DataAnnotations;

namespace SchoolSystemBackend.Models.Entities
{
    public class Grade
    {
        [Key]
        public Guid GradeId { get; set; }
        public required string GradeName { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
        public Guid? StreamId { get; set; }
        public ClassStream? ClassStream { get; set; }
    }
}
