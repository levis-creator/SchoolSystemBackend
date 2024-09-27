using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Models.Dtos.Staff
{
    public class UpdateStaffDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int NationalId { get; set; }
        public DateOnly EntranceDate { get; set; }
    }
}
