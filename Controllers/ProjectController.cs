using Microsoft.AspNetCore.Mvc;
using ProjectsAPI.Data;
using ProjectsAPI.Data.Entities;

namespace projects_api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectsApiDbContext _dbContext;

        public ProjectController(ProjectsApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok();
        }

        [HttpGet]
        [Route("completed")]
        public IActionResult GetCompletedProjects()
        {
            return Ok();
        }

        [HttpGet]
        [Route("top")]
        public IActionResult GetTopProjectsByRevenue()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            return Ok();
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProject([FromRoute]int id)
        {
            return Ok();

        }

    }
}
