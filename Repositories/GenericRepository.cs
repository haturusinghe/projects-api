using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data;
using ProjectsAPI.Repositories.Interfaces;

namespace ProjectsAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ProjectsApiDbContext _context;
        internal DbSet<T> _dbSet;

       public GenericRepository(ProjectsApiDbContext context)
        {
            // initiate the context and the logger through dependency injection
            _context = context;

            this._dbSet = context.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
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

        public async Task<T> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }
    }

}
