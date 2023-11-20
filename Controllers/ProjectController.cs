using Microsoft.AspNetCore.Mvc;
using projects_api.Models;

namespace projects_api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private static List<Project> _projects = new List<Project>
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
        public IActionResult GetAllProjects()
        {
            if(_projects == null || _projects.Count == 0)
            {
                return NotFound("No projects found");
            }

            return Ok(_projects);
        }

        [HttpGet]
        [Route("completed")]
        public IActionResult GetCompletedProjects()
        {
            var completed =  _projects.FindAll(p => p.IsCompleted == true);

            if(completed == null)
            {
                return NotFound("No Completed Projects Found");
            }

            return Ok(completed);
        }

        [HttpGet]
        [Route("top")]
        public IActionResult GetTopProjectsByRevenue()
        {
            var top3 = _projects.Where(p=> p.Revenue > 0).OrderByDescending(p => p.Revenue).Take(3).ToList();

            if(top3 == null)
            {
                return NotFound("No top performing projects found");
            }

            return Ok(top3);
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            try
            {
                var isValid = IsValidProject(project);

                if (!isValid)
                {
                    return BadRequest("Project data is not valid");
                }


                if (DoesProjectNameExist(project))
                {
                    return BadRequest("Project with same name already exists");
                }

                var maxProjectId = _projects.Max(p => p.Id);
                project.Id = maxProjectId + 1;

                _projects.Add(project);

                return Ok(project);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProject([FromRoute]int id)
        {
            var project = _projects.Find(p => p.Id == id);

            if (project == null)
            {
                return NotFound("Project with ID:" + id + " not found");
            }
            _projects.Remove(project);
            return Ok(project);
            
            
        }

        private bool DoesProjectNameExist(Project project)
        {
            //check if _projects has a project with the same name
            var existingProject = _projects.Find(p => p.Name == project.Name);

            if (existingProject != null)
                return true;
            else
                return false;
        }

        private bool IsValidProject(Project project)
        {
            if (project == null || project.Name.Length <= 0)
            {
                return false;
            }

            return true;
        }

    }
}
