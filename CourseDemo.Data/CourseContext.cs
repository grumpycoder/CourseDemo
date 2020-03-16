using CourseDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseDemo.Data
{
    public class CourseContext : DbContext
    {

        // public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        // {
        //     ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // }

        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        { }
        
        // public CourseContext() 
        // {
        //     ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // }
        
        public DbSet<Course> Courses { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     string connectionString = "Server=.;Database=CourseDemo;User Id=sa;Password=P@55w0rd;";
        //     optionsBuilder.UseSqlServer(connectionString);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseLevel>().ToTable("CourseLevels");
            modelBuilder.Entity<CourseType>().ToTable("CourseTypes");
            modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<DeliveryType>().ToTable("DeliveryTypes");
            modelBuilder.Entity<Tag>().ToTable("Tags");
        }
    }
}