using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Models.Dtos.Student;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;
        public AppUserController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        //Staff
        [HttpPost("staff")]
        public IActionResult AddStaff([FromBody] AddStaffDto staffDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var staff = _appUserRepository.CreateStaff(staffDto);
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }

        }
        
        [HttpGet("staff")]
        public IActionResult GetAllStaff()
        {
            var staff = _appUserRepository.GetAllStaff();
            return Ok(staff);
        }

        [HttpGet("staff/{id:int}")]
        public IActionResult GetStaff(int id)
        {
            var staff = _appUserRepository.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpPut("staff/{id:int}")]
        public IActionResult UpdateStaff(int id, [FromBody] UpdateStaffDto updateStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var staff = _appUserRepository.UpdateStaffById(id, updateStaffDto);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpDelete("staff/{id:int}")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = _appUserRepository.GetStaffById(id);
            if(staff == null)
            {
                return NotFound();
            }
            _appUserRepository.DeleteStaffById(id);
            return NoContent();
        }

        //students
        [HttpPost("students")]
        public IActionResult AddStudent([FromBody] AddStudentDto studentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var student = _appUserRepository.CreateStudent(studentDto);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
  
        [HttpGet("students")]
        public IActionResult GetAllStudents()
        {
            var students = _appUserRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("students/{id:int}")]
        public IActionResult GetStudent(int id)
        {
            var student = _appUserRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("students/{id:int}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student= _appUserRepository.UpdateStudentById(id, updateStudentDto);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpDelete("students/{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _appUserRepository.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            _appUserRepository.DeleteStudentById(id);
            return NoContent();
        }
    }
}
