using ProjectsAPI.Data.Entities;

namespace ProjectsAPI.Repositories.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<IEnumerable<Project>> GetTopByRevenue();
        Task<IEnumerable<Project>> GetCompleted();
    }
}
