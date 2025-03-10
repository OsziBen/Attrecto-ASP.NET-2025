﻿using System.ComponentModel.DataAnnotations;

namespace CourseController.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        //[Required]
        //public User? Author { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }

        // ADATBÁZIS RELÁCIÓK
        public ICollection<User> Users { get; set; } = [];
    }
}
