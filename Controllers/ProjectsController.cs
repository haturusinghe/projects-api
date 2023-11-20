using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projects_api.models;

namespace projects_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {

        private readonly ProjectContext _projectcontext;
        public ProjectsController(ProjectContext projectContext) 
        { 
            _projectcontext = projectContext;
        }

        [HttpGet]
        public async  Task<IActionResult> getAllProjects()
        {
           var projects =  await _projectcontext.Projects.ToListAsync();

           return Ok(projects);
        }
    }
}
