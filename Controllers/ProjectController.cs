using Microsoft.AspNetCore.Mvc;
using ProjectsAPI.Data;
using ProjectsAPI.Data.Entities;
using ProjectsAPI.Repositories.Interfaces;

namespace ProjectsAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _unitOfWork.Projects.GetAll());
        }

        [HttpGet]
        [Route("completed")]
        public async Task<IActionResult> GetCompletedProjects()
        {
            return Ok(await _unitOfWork.Projects.GetCompleted());
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTopProjectsByRevenue()
        {
            return Ok(await _unitOfWork.Projects.GetTopByRevenue());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            await _unitOfWork.Projects.Create(project);
            await _unitOfWork.CompleteAsync();
            return Ok(project);

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var project = await _unitOfWork.Projects.GetById(id);

            if(project == null)
            {
                return NotFound();
            }

            await _unitOfWork.Projects.Delete(project);

            await _unitOfWork.CompleteAsync();
            
            
            return Ok(project);

        }

    }
}
