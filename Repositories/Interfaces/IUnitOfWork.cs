using ProjectsAPI.Data.Entities;

namespace ProjectsAPI.Repositories.Interfaces
{
    // for every table we have a set of instructions , since we are using dependency injection we need to create an interface for each table
    // we can map the interface to the table using the generic repository
    public interface IUnitOfWork //using unit of work to abstract the database logic
    {
        IProjectRepository Projects { get; }

        Task CompleteAsync(); //refers to saving changes to the database
    }
}
