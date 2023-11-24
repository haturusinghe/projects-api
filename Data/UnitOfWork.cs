using ProjectsAPI.Repositories;
using ProjectsAPI.Repositories.Interfaces;

namespace ProjectsAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProjectsApiDbContext _context;
        public IProjectRepository Projects { get; private set; }

        public UnitOfWork(ProjectsApiDbContext context)
        {
            _context = context;
            
            Projects = new ProjectRepository(_context);
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
