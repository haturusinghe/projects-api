using Microsoft.AspNetCore.Mvc;
using ProjectsAPI.Data.Entities;

namespace ProjectsAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {


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
            return Ok(project);

        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProject([FromRoute] int id)
        {
            return Ok(id);

        }

    }
}
