using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface IStudentRepository
    {
        //get all data
        IEnumerable<Student> GetAllStudents();
        //Create data
        Student CreateStudent(AddStudentDto addStudentDto);
        //Create single data
        Student? GetStudentById(int id);
        //update
        Student? UpdateStudentById(int id, UpdateStudentDto updateStudentDto);
        //delete
        void DeleteStudentById(int id);
        //adding Multiple Data
        dynamic AddManyStudent(IEnumerable<AddStudentDto> studentsDto);

    }
}
