using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolSystemBackend.Data;

using SchoolSystemBackend.Models.Dtos.NextOfKins;
using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;
using System.Dynamic;

namespace SchoolSystemBackend.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;
        public AppUserRepository(AppDbContext context, INextOfKinRepository nextOfKinRepository)
        {
            _context = context;

        }


        //Adding  data to db
        public Staff CreateStaff(AddStaffDto addStaffDto)
        {
            var staff = new Staff()
            {
                FirstName = addStaffDto.FirstName,
                LastName = addStaffDto.LastName,
                Gender = addStaffDto.Gender,
                DateOfBirth = addStaffDto.DateOfBirth,
                Department = addStaffDto.Department,
                NationalId = addStaffDto.NationalId,
                EntranceDate = addStaffDto.EntranceDate,
            };

            _context.Staff.Add(staff);
            _context.SaveChanges();
            return staff;
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

        //deleting data from db
        public void DeleteStaffById(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                _context.SaveChanges();
            }
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

        //fetching all data from db
        public IEnumerable<Staff> GetAllStaff()
        {
            var staffs = _context.Staff.ToList();
            return staffs;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = _context.Students.Include(e => e.NextOfKins).ToList();
            return students;
        }

        //fetching single data from db
        public Staff? GetStaffById(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff != null)
            {
                return staff;
            }
            return null;
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
        //updating data in db
        public Staff? UpdateStaffById(int id, UpdateStaffDto updateStaffDto)
        {
            var staff = _context.Staff.Find(id);
            if (staff != null)
            {
                staff.FirstName = updateStaffDto.FirstName;
                staff.LastName = updateStaffDto.LastName;
                staff.Gender = updateStaffDto.Gender;
                staff.DateOfBirth = updateStaffDto.DateOfBirth;
                staff.EntranceDate = updateStaffDto.EntranceDate;
                staff.Department = updateStaffDto.Department;
                staff.LastUpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return staff;
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
    }
}
