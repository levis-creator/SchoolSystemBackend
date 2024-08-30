using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/users/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        IStaffRepository staffRepository;

        public StaffController(IStaffRepository _staffRepository)
        {
          staffRepository = _staffRepository;
        }


        //Staff
        [HttpPost]
        public IActionResult AddStaff([FromBody] AddStaffDto staffDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var staff = staffRepository.CreateStaff(staffDto);
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpGet]
        public IActionResult GetAllStaff()
        {
            var staff = staffRepository.GetAllStaff();
            return Ok(staff);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStaff(int id)
        {
            var staff = staffRepository.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStaff(int id, [FromBody] UpdateStaffDto updateStaffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var staff = staffRepository.UpdateStaffById(id, updateStaffDto);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = staffRepository.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            staffRepository.DeleteStaffById(id);
            return NoContent();
        }

    }
}
