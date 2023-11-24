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
    }
}
