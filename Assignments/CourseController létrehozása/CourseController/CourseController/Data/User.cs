using System.ComponentModel.DataAnnotations;

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

        [Required]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
        public int Age { get; set; }
    }
}
