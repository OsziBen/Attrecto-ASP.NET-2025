﻿using System.ComponentModel.DataAnnotations;

namespace CourseController.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
    }
}
