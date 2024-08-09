using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;
        public AppUserRepository(AppDbContext context)
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
            var student = new Student()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                Gender = addStudentDto.Gender,
                AdmissionDate = addStudentDto.AdmissionDate,
                DateOfBirth = addStudentDto.DateOfBirth,
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        //deleting data from db
        public void DeleteStaffById(int id)
        {
            var staff= _context.Staff.Find(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                _context.SaveChanges();
            }
        }

        public void DeleteStudentById(int id)
        {
           var student= _context.Students.Find(id);
            if(student != null)
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
            var students = _context.Students.ToList();
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
    }
}
