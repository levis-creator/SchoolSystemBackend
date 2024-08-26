using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NextOfKinsController : ControllerBase
    {
        private INextOfKinRepository nextOfKinRepository;

        public NextOfKinsController(INextOfKinRepository nextOfKinRepository)
        {
            this.nextOfKinRepository = nextOfKinRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var nextOfKin = nextOfKinRepository.GetAll();
            return Ok(nextOfKin);
        }
    }
}
