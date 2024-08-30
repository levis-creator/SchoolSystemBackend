using Microsoft.EntityFrameworkCore;
using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;
using System.Dynamic;

namespace SchoolSystemBackend.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) { _context = context; }

        public dynamic AddManyStudent(IEnumerable<AddStudentDto> studentsDto)
        {
            dynamic countItems = new ExpandoObject();
            countItems.saved = 0;
            countItems.failed = 0;
            foreach (var studentDto in studentsDto)
            {
                var savedStudent = CreateStudent(studentDto);
                if (savedStudent != null)
                {
                    countItems.saved++;
                }
                else
                {
                    countItems.failed++;
                }
            }
            return countItems;
        }

        public Student CreateStudent(AddStudentDto addStudentDto)
        {
            // Check if addStudentDto is null
            if (addStudentDto == null)
            {
                throw new ArgumentNullException(nameof(addStudentDto), "Student data is required.");
            }

            // Create new student instance
            var student = new Student
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                Gender = addStudentDto.Gender,
                AdmissionDate = addStudentDto.AdmissionDate,
                DateOfBirth = addStudentDto.DateOfBirth
            };

            // Check if NextOfKins is provided and process it
            if (addStudentDto.NextOfKins != null && addStudentDto.NextOfKins.Any())
            {
                foreach (var nextOfKinDto in addStudentDto.NextOfKins)
                {
                    NextOfKin nextOfKinEntity;

                    // Check if the NextOfKin already exists by NationalId
                    var existingNextOfKin = _context.NextOfKins
                        .SingleOrDefault(e => e.NationalId == nextOfKinDto.NationalId);

                    if (existingNextOfKin != null)
                    {
                        // Use the existing NextOfKin if found
                        nextOfKinEntity = existingNextOfKin;
                    }
                    else
                    {
                        // Create a new NextOfKin if not found
                        nextOfKinEntity = new NextOfKin
                        {
                            FirstName = nextOfKinDto.FirstName,
                            LastName = nextOfKinDto.LastName,
                            NationalId = nextOfKinDto.NationalId,
                            PhoneNumber = nextOfKinDto.PhoneNumber,
                            Relationship = nextOfKinDto.Relationship,
                            EmailAddress = nextOfKinDto.EmailAddress
                        };

                        // Add the new NextOfKin to the context
                        _context.NextOfKins.Add(nextOfKinEntity);
                    }

                    // Add the NextOfKin to the student
                    student.NextOfKins.Add(nextOfKinEntity);
                }
            }

            // Add the new student to the context
            _context.Students.Add(student);

            // Save changes to the database
            _context.SaveChanges();

            return student;
        }

        public void DeleteStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }


        public IEnumerable<Student> GetAllStudents()
        {
            var students = _context.Students.Include(e => e.NextOfKins).ToList();
            return students;
        }

        public Student? GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                return student;
            }
            return null;

        }

        public Student? UpdateStudentById(int id, UpdateStudentDto updateStudentDto)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {

                student.FirstName = updateStudentDto.FirstName;
                student.LastName = updateStudentDto.LastName;
                student.Gender = updateStudentDto.Gender;
                student.AdmissionDate = updateStudentDto.AdmissionDate;
                student.DateOfBirth = updateStudentDto.DateOfBirth;
                student.LastUpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return student;
            }
            return null;
        }
    }
}
