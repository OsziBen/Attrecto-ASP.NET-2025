using Microsoft.EntityFrameworkCore;

namespace Academy_2025.Data
{
    public class ApplicationDbContext : DbContext
    {
        //private string DbPath;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            /*
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = Path.Join(path, "academy.db");
            */
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
        */
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
