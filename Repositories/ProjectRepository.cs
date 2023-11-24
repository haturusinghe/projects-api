using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data;
using ProjectsAPI.Data.Entities;
using ProjectsAPI.Repositories.Interfaces;

namespace ProjectsAPI.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsApiDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Project>> GetCompleted()
        {
            try
            {
                return await _context.Projects.Where(p => p.IsCompleted).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get completed projects: {ex}");
                return null;
            }
        }

        public async Task<IEnumerable<Project>> GetTopByRevenue()
        {
            try
            {
                return await _context.Projects.Where(p=> p.Revenue > 0).OrderByDescending(p => p.Revenue).Take(3).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get top projects by revenue: {ex}");
                return null;
            }
        }
    }
}
