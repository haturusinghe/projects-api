using ProjectsAPI.Repositories;
using ProjectsAPI.Repositories.Interfaces;

namespace ProjectsAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProjectsApiDbContext _context;
        private readonly ILogger _logger;
        public IProjectRepository Projects { get; private set; }

        public UnitOfWork(ProjectsApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            
            Projects = new ProjectRepository(_context, _logger);
        }
        


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync(); 
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
