using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SchoolSystemBackend.Models.Entities
{
    public class NextOfKin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public required string PhoneNumber { get; set; }
        public required string Relationship { get; set; }
        public int NationalId {  get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
    }
}
