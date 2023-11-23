using Microsoft.AspNetCore.Mvc;

namespace ProjectsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}
