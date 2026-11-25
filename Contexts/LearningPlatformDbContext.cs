using Microsoft.EntityFrameworkCore;
using Online__Learning_Platform.Configrations;
using Online__Learning_Platform.Modals;
using System.Data;


namespace Online__Learning_Platform.Contexts
{
    internal class LearningPlatformDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=OnlineLearningPlatForm;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigration());
            modelBuilder.ApplyConfiguration(new CourseConfigration());
            modelBuilder.ApplyConfiguration(new InstructoConfigration());
            modelBuilder.ApplyConfiguration(new StudentConfigration());
            modelBuilder.ApplyConfiguration(new StudentCoursesConfigration());
        }

        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentCourses> studentCourses { get; set; }

    }
}
