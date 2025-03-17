using Microsoft.EntityFrameworkCore;

namespace CourseController.Data
{
    public class ApplicationDbContext : DbContext
    {
        //private string DbPath;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // A User és Course táblákk közti Many-Many kapcsolat beállítása
            modelBuilder.Entity<User>()
                .HasMany(u => u.Courses)
                .WithMany(c => c.Users)
                .UsingEntity(j => j.ToTable("UserCourses"));

            // A Course és User közötti Author kapcsolat beállítása
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
