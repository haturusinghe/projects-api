using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data;
using ProjectsAPI.Repositories.Interfaces;

namespace ProjectsAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ProjectsApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

       public GenericRepository(ProjectsApiDbContext context, ILogger logger)
        {
            // initiate the context and the logger through dependency injection
            _context = context;
            _logger = logger;


            this._dbSet = context.Set<T>();
        }

        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
