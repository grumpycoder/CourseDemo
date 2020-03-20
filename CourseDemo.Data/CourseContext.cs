using CourseDemo.Domain;
using CourseDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CourseDemo.Data
{
    public class CourseContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        
        
        // public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        // {
        //     ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // }

        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _useConsoleLogger = true; 
            
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

            optionsBuilder.UseLazyLoadingProxies();
            
            if (_useConsoleLogger)
            {
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging();
            }
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(x =>
            {
                x.ToTable("Courses", "Common");
                x.HasMany(p => p.ProgramAssignments).WithOne(p => p.Course)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

                x.OwnsOne(p => p.ValidPeriod, p =>
                {
                    p.Property(pp => pp.BeginYear).HasColumnName("BeginYear");
                    p.Property(pp => pp.EndYear).HasColumnName("EndYear");
                });
               
            });

            // modelBuilder.Entity<Program>(x =>
            // {
            //     x.ToTable("Programs", "CareerTech");
            //     x.Property(p => p.Id).HasColumnName("Id"); 
            // }); 

            modelBuilder.Entity<Program>(x =>
            {
                x.ToTable("Programs", "CareerTech");
                x.OwnsOne(p => p.ValidPeriod, p =>
                {
                    p.Property(pp => pp.BeginYear).HasColumnName("BeginYear");
                    p.Property(pp => pp.EndYear).HasColumnName("EndYear");
                }); 
                    
            }); 
            
            modelBuilder.Entity<Cluster>(x =>
            {
                x.ToTable("Clusters", "CareerTech");
                x.OwnsOne(p => p.ValidPeriod, p =>
                {
                    p.Property(pp => pp.BeginYear).HasColumnName("BeginYear");
                    p.Property(pp => pp.EndYear).HasColumnName("EndYear");
                }); 
                    
            }); 
            
            modelBuilder.Entity<CourseLevel>().ToTable("CourseLevels", "Common");
            modelBuilder.Entity<CourseType>().ToTable("CourseTypes", "Common");
            modelBuilder.Entity<Grade>().ToTable("Grades", "Common");
            modelBuilder.Entity<DeliveryType>().ToTable("DeliveryTypes", "Common");
            modelBuilder.Entity<Tag>().ToTable("Tags", "Common");

            modelBuilder.Entity<ProgramAssignment>(x =>
            {
                x.ToTable("ProgramCourses", "CareerTech");
                x.OwnsOne(p => p.ValidPeriod, p =>
                {
                    p.Property(pp => pp.BeginYear).HasColumnName("BeginYear");
                    p.Property(pp => pp.EndYear).HasColumnName("EndYear");
                }); 
            });

        }
    }
}