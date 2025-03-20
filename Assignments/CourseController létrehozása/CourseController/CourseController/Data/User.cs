using System.ComponentModel.DataAnnotations;

namespace CourseController.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; } = string.Empty;

        public required string Role { get; set; } = string.Empty;

        public required int Age { get; set; }

        // ADATBÁZIS RELÁCIÓK
        public ICollection<Course> Courses { get; set; } = [];
    }
}
