using CourseController.Data;
using CourseController.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course?> GetByIdAsync(int id)
        {
            return _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Course?> UpdateAsync(int id, Course data)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                course.Name = data.Name;
                course.Description = data.Description;

                if (data.AuthorId.HasValue)
                {
                    course.AuthorId = data.AuthorId.Value;
                }

                await _context.SaveChangesAsync();

                return course;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
