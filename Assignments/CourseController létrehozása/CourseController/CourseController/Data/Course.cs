using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseController.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ezt az értéket tárolja az adatbázis
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Ez egy navigációs tulajdonság, amit explicit nem tárol az adatbázis, hanem abból tudjuk kiolvasni
        /// a későbbi műveletvégzéshez. ezt a EF automatikusan betölti a course adataival együtt
        /// </summary>
        [ForeignKey("AuthorId")]
        public User? Author { get; set; }

        public required string Description { get; set; } = string.Empty;

        // ADATBÁZIS RELÁCIÓK
        public ICollection<User> Users { get; set; } = [];
    }
}
