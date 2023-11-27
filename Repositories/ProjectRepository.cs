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

        public override async Task<Project> Create(Project entity)
        {
            entity.Id = 0;
            await base.Create(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Project> Delete(Project entity)
        {
            await base.Delete(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Project?> DeleteById(int id)
        {
            var project = await GetById(id);

            if(project != null)
            {
               return await Delete(project);
            }

            return null;
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
