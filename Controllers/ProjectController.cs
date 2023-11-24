using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projects_api.models;

namespace Projects_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {

        private readonly ProjectContext _projectcontext;
        public ProjectController(ProjectContext projectContext)
        {
            _projectcontext = projectContext;
        }

        [HttpGet]
        public async Task<IActionResult> getAllProjects()
        {
            var projects = await _projectcontext.Projects.ToListAsync();
            return Ok(projects);
        }
    }
}
