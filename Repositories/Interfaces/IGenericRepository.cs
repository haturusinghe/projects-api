namespace ProjectsAPI.Repositories.Interfaces
{
    //make a generic interface , because in the database there are multiple tables, we dont need to recreate interfaces for default patterns for all of them
    //instead we can create a generic interface and use it for all of them
    public interface IGenericRepository<T> where T : class
    {
        //these are the usual actions we do with each entity
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
