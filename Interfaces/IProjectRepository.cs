using ProjectsAPI.Data.Entities;

namespace ProjectsAPI.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<Project?> DeleteById(int id);
        Task<IEnumerable<Project>> GetCompleted();
        Task<IEnumerable<Project>> GetTopByRevenue();
    }
}
