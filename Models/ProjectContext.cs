
using Microsoft.EntityFrameworkCore;
namespace Project_Mvc.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base()
        {

        }
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=Project;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }



    }
}
