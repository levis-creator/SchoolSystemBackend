using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface IAppUserRepository
    {
        //get all data
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Staff> GetAllStaff();
        //create data
        Staff CreateStaff(AddStaffDto addStaffDto);
        Student CreateStudent(AddStudentDto addStudentDto);
        //get singledata
        Staff? GetStaffById(int id);
        Student? GetStudentById(int id);
        //update
        Student? UpdateStudentById(int id, UpdateStudentDto updateStudentDto); 
        Staff? UpdateStaffById(int id, UpdateStaffDto updateStaffDto);
        //delete
        void DeleteStudentById(int id);
        void DeleteStaffById(int id);

    }
}
