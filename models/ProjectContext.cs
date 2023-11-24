using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
