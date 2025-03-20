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
            
            return _context.Courses.Include(c => c.Author).ToListAsync();
        }

        public Task<Course?> GetByIdAsync(int id)
        {
            return _context.Courses
                .Include(c => c.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AuthorExistsAsync(int authorId)
        {
            return await _context.Users.AnyAsync(u => u.Id == authorId);
        }

        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync()
            => _context.SaveChangesAsync();

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
