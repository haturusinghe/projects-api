using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data;
using ProjectsAPI.Interfaces;

namespace ProjectsAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ProjectsApiDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(ProjectsApiDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
           return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);    
        }

        public virtual async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
