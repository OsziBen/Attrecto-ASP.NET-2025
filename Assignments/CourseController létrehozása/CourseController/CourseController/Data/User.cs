using System.ComponentModel.DataAnnotations;

namespace CourseController.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        /*
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        */

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string? Role { get; set; }

        // database relations
        public ICollection<Course> Courses { get; set; } = [];

        public ICollection<Course> OwnCourses { get; set; } = [];
    }
}
