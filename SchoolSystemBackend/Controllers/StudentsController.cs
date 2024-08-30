using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Repositories;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/users/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentRepository studentRepository;

        public StudentsController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        //students
        [HttpPost]
        public IActionResult AddStudent([FromBody] AddStudentDto studentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var student = studentRepository.CreateStudent(studentDto);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpPost("/many")]
        public IActionResult AddStudents([FromBody] List<AddStudentDto> addStudents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var students = studentRepository.AddManyStudent(addStudents);
            return Ok(students);
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = studentRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudent(int id)
        {
            var student = studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = studentRepository.UpdateStudentById(id, updateStudentDto);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            studentRepository.DeleteStudentById(id);
            return NoContent();
        }
    }
}
