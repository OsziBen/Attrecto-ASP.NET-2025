using Microsoft.EntityFrameworkCore;

namespace CourseController.Data
{
    public class ApplicationDbContext : DbContext
    {
        //private string DbPath;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //DbPath = Path.Join(path, "academyAssignment.db");
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany(u => u.OwnCourses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Courses)
                .UsingEntity(j => j.ToTable("CourseParticipants"));

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
