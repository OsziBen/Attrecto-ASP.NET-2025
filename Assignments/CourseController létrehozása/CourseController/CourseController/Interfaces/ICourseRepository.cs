using CourseController.Data;

namespace CourseController.Interfaces
{
    public interface ICourseRepository
    {
        Task<bool> AuthorExistsAsync(int authorId);
        Task CreateAsync(Course data);
        Task<bool> DeleteAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<int> UpdateAsync();
    }
}