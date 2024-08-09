using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Models.Dtos.Student
{
    public class AddStudentDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public GenderType Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly AdmissionDate { get; set; } 
    }

}
