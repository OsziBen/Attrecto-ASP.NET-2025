using System.ComponentModel.DataAnnotations;

namespace CourseController.Dtos
{
    public class FilteredCourseDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public FilteredUserDto? Author { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
