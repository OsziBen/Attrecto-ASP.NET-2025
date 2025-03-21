using CourseController.Dtos;

namespace CourseController.Interfaces
{
    public interface ICourseService
    {
        Task CreateAsync(CourseDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<FilteredCourseDto>> GetAllAsync();
        Task<FilteredCourseDto?> GetByIdAsync(int id);
        Task<CourseDto?> UpdateAsync(int id, CourseDto data);
    }
}
