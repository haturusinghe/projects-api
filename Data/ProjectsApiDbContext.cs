using Microsoft.EntityFrameworkCore;
using ProjectsAPI.Data.Entities;

namespace ProjectsAPI.Data
{
    public class ProjectsApiDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public ProjectsApiDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
