using System.ComponentModel.DataAnnotations;

namespace CourseController.Data
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
    }
}
