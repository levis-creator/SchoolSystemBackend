using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Models.Dtos.Stream;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassStreamController : ControllerBase
    {
        private IClassStreamRepository _classStreamRepository;
        public ClassStreamController(IClassStreamRepository classStreamRepository)
        {
            _classStreamRepository = classStreamRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var classStream = _classStreamRepository.GetAllClassStreams();
            return Ok(classStream);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddClassStreamDto classStreamDto)
        {
            if (!ModelState.IsValid)
            {
                // Return a BadRequest with validation errors
                return BadRequest(ModelState);
            }

            var createClass = _classStreamRepository.CreateClassStream(classStreamDto);
            return Ok(createClass);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateClassStreamDto updateClassStream)
        {
            if (!ModelState.IsValid)
            {
                // Return a BadRequest with validation errors
                return BadRequest(ModelState);
            }
            var streamExist=_classStreamRepository.GetClassStreamById(id);
            if (streamExist == null)
            {
                return NotFound();
            }
            var updateStream = _classStreamRepository.UpdateClassStream(id, updateClassStream);
            if (updateStream != null)
            {
                return Ok(updateStream);
            }
            return BadRequest(ModelState);
          
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existClass = _classStreamRepository.GetClassStreamById(id);
            if (existClass == null)
            {
               return NotFound();
            }
            var deleteClass = _classStreamRepository.DeleteClassStream(id);
            if (deleteClass == true)
            {
                return NoContent();
            }
            return BadRequest();
        }

    }
}
