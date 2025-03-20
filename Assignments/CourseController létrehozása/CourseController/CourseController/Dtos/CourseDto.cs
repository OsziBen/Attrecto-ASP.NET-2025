using CourseController.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseController.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public UserDto? Author { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
