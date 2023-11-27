using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data;
using ProjectsAPI.Data.Entities;
using ProjectsAPI.Interfaces;

namespace ProjectsAPI.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _projectRepository.GetAll());
        }

        [HttpGet]
        [Route("completed")]
        public async Task<IActionResult> GetCompletedProjects()
        {
            return Ok(await _projectRepository.GetCompleted());
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTopProjectsByRevenue()
        {
            return Ok(await _projectRepository.GetTopByRevenue());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            return Ok(await _projectRepository.Create(project));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute]int id)
        {
            var project = await _projectRepository.DeleteById(id);
            if(project == null)
            {
                return NotFound();
            }
            return Ok(project);

        }

    }
}
