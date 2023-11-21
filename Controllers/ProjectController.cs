using Microsoft.AspNetCore.Mvc;

namespace projects_api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok("Hello");
        }
    }
}
