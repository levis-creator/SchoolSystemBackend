using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Models.Dtos.Grade;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private IGradesRepository gradesRepository;

        public GradesController(IGradesRepository gradesRepository)
        {
            this.gradesRepository = gradesRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var grades = gradesRepository.GetAllGrades();
            return Ok(grades);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddGradeDto gradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var grades = gradesRepository.CreateGrade(gradeDto);
            return Ok(grades);
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateGradeDto gradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedGrade = gradesRepository.UpdateGrade(id, gradeDto);
            if (updatedGrade != null)
            {
                return Ok(updatedGrade);
            }
            return NotFound();
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var _gradeExists = gradesRepository.GetGradeById(id);
            if (_gradeExists == null)
            {
                return NotFound();
            }
            var deletedGrade = gradesRepository.DeleteGrade(id);
            return Ok(deletedGrade);
        }
    }
}
