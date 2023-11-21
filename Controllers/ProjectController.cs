using Microsoft.AspNetCore.Mvc;
using projects_api.Models;

namespace projects_api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly Project[] _projects = new Project[]
        {
           new Project { Id = 1, Name = "Project Breeze", Revenue = 12365.55, IsCompleted = true },
           new Project { Id = 2, Name = "Command Program", Revenue = 4598.5, IsCompleted = false },
           new Project { Id = 3, Name = "Project Point", Revenue = 6549.75, IsCompleted = true },
           new Project { Id = 4, Name = "Project Mecha", Revenue = 15614.25, IsCompleted = false },
           new Project { Id = 5, Name = "Program Pad", Revenue = 16545.0, IsCompleted = true },
           new Project { Id = 6, Name = "Project Synergy", Revenue = 12456.0, IsCompleted = false },
           new Project { Id = 7, Name = "Dynamic Program", Revenue = 1564.5, IsCompleted = true },
           new Project { Id = 8, Name = "Project ZenSen", Revenue = 12312.75, IsCompleted = false },
        };

        [HttpGet]
        public IActionResult GetProjects()
        {
            if (_projects.Length == 0)
                return NotFound("Projects not found!");
            return Ok(_projects);
        }

        [HttpGet]
        [Route("top")]
        public IActionResult GetTopProjects()
        {
            Project[] topProjects = _projects.OrderByDescending(p => p.Revenue).Take(3).ToArray();

            if (topProjects.Length == 0)
                return NotFound("Projects not found!");
            return Ok(topProjects);
        }

        [HttpGet]
        [Route("completed")]
        public IActionResult GetCompletedProjects()
        {
            Project[] completedProjects = _projects.Where(p => p.IsCompleted).ToArray();

            if (completedProjects.Length == 0)
                return NotFound("Completed projects not found!");
            return Ok(completedProjects);
        }
    }
}
