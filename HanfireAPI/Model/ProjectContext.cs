using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HanfireAPI.Model
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base (options) { }

        public DbSet<Student> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData
                (
                     new Student { Id = 1, Name = "Muzamil"},
                     new Student { Id = 2, Name = "Asad Ali"},
                     new Student { Id = 3, Name = "Majid Ali"}
                );
        }

    }
}
