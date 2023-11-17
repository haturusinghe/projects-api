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
        public List<Project> GetAllProjects()
        {
            return _projects;
        }

        [HttpGet]
        [Route("completed")]
        public List<Project> GetCompletedProjects()
        {
            return _projects.FindAll(p => p.IsCompleted == true);
        }

        [HttpGet]
        [Route("top")]
        public List<Project> GetTopProjectsByRevenue()
        {
            return _projects.ToList().OrderByDescending(p => p.Revenue).Take(3).ToList();
        }

        [HttpPost]
        public Project CreateProject(Project project)
        {
            var isValidProject = validateProject(project);

            var maxProjectId = _projects.Max(p => p.Id);
            project.Id = maxProjectId + 1;

            _projects.Add(project);

            return project;
        }

        [HttpDelete]
        [Route("{id}")]
        public Project DeleteProject([FromRoute]int id)
        {
            var project = _projects.Find(p => p.Id == id);

            if (project != null)
            {
                _projects.Remove(project);
            }

            return project;
        }

        private bool validateProject(Project project)
        {
            if (_projects.Any(p => p.Id == project.Id) || _projects.Any(p => p.Name.ToLower().Equals(project.Name.ToLower())))
            {
                return false;
            }

            return true;
        }
    }
}
