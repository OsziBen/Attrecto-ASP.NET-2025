using CourseController.Data;
using CourseController.Interfaces;

namespace CourseController.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        //public static List<Course>? Courses = new List<Course>();
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                course.Name = data.Name;
                //course.Author = data.Author;
                course.Description = data.Description;
                _context.SaveChanges();

                return course;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
