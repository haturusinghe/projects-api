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

        public virtual async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> Delete(int id)
        {
            var project  = await _dbSet.FindAsync(id);
            if(project == null)
            {
                return null;
            }

            _dbSet.Remove(project);
            return project;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {   
            // this can be null
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }

}
