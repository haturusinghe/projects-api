using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data;
using ProjectsAPI.Data.Entities;
using ProjectsAPI.Interfaces;

namespace ProjectsAPI.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsApiDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Project>> GetCompleted()
        {
           return await _context.Projects.Where(p => p.IsCompleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetTopByRevenue()
        {
            return await _context.Projects.Where(p => p.Revenue > 0).
                OrderByDescending(p => p.Revenue).Take(3).ToListAsync(); 
        }
    }
}
