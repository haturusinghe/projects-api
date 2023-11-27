using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _dbContext.Projects.ToListAsync();
            return Ok(projects);
        }

        [HttpGet]
        [Route("completed")]
        public async Task<IActionResult> GetCompletedProjects()
        {
            var completedProjects = await _dbContext.Projects.Where(p => p.IsCompleted).ToListAsync();
            return Ok(completedProjects);
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTopProjectsByRevenue()
        {
            var topProjects = await _dbContext.Projects.Where(p=> p.Revenue > 0).OrderByDescending(p => p.Revenue).Take(3).ToListAsync();
            return Ok(topProjects);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return Ok(project);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute]int id)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
            return Ok(project);

        }

    }
}
