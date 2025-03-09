using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseController.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User? Author { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }

        // database relations
        public ICollection<User> Users { get; set; } = [];
    }
}
