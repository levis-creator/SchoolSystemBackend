using System.ComponentModel.DataAnnotations;

namespace SchoolSystemBackend.Models.Entities
{
    public enum GenderType
    {
        [Display(Name ="Male")]
        Male,
        [Display(Name ="Female")]
        Female,
        [Display(Name = "Other")]
        Other
    }
    public abstract class AppUser
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime LastUpdatedAt { get; set; }=DateTime.Now;
    }
}
