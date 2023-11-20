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

           if(projects.Count == 0)
            {
                return NotFound("Projects Not Found");
            }
            else
            {
                return Ok(projects);
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> createProject([FromBody] Project project)
        {
            //Generate Random id for Project
            Random rnd = new Random();
            project.Id = rnd.Next(100);

            if(project.Name == null)
            {
                return BadRequest("Please Enter Project Name");    
            }
            if (project.Revenue == 0)
            {
                return BadRequest("Please Enter Project Revenue");
            }

            await _projectcontext.Projects.AddAsync(project);
            await _projectcontext.SaveChangesAsync();

            return Ok(project);

        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> getTopProjectsByRevenue()
        {
            var projects = await _projectcontext.Projects.ToListAsync();
            var topProjects = projects.OrderByDescending(p => p.Revenue).Take(3).ToList();

            if(topProjects.Count == 0)
            {
                return NotFound("No Top Performed Projects Yet");
            }
            else
            {
                return Ok(topProjects);
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deleteProject([FromRoute] int id)
        {
            var project = await _projectcontext.Projects.FindAsync(id);

            if(project == null)
            {
                return NotFound();
            }
            _projectcontext.Projects.Remove(project);

            await _projectcontext.SaveChangesAsync();

            return Ok();
        }

    }
}
