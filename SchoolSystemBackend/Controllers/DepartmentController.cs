using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Models.Dtos.Departments;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Get() {
        var departments= _departmentRepository.GetAllDepartments();
           return Ok(departments);
        }
        [HttpPost]
        public IActionResult Post([FromBody]AddDepartmentDto departmentDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department= _departmentRepository.CreateDepartment(departmentDto);
            if (department == null) {
                return BadRequest(departmentDto);
            }
           
           return Ok(department);
        }

    }
}
