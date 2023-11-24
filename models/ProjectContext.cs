using Microsoft.EntityFrameworkCore;

namespace Projects_api.models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; } = null!;
    }
}
