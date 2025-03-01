﻿using Microsoft.EntityFrameworkCore;

namespace CourseController.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string DbPath;

        public ApplicationDbContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = Path.Join(path, "academyAssignment.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
