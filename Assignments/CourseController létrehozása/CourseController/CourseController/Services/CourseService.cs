using CourseController.Dtos;
using CourseController.Helper;
using CourseController.Interfaces;

namespace CourseController.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task CreateAsync(CourseDto data)
        {
            var authorExists = await _courseRepository.AuthorExistsAsync(data.AuthorId);

            if (!authorExists)
            {
                throw new ArgumentException($"User with ID {data.AuthorId} not found.");
            }

            await _courseRepository.CreateAsync(DtoConverter.MapToModel(data));
        }
            

        public Task<bool> DeleteAsync(int id)
            => _courseRepository.DeleteAsync(id);

        public async Task<List<FilteredCourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();

            return courses.Select(DtoConverter.MapToFilteredDto).ToList();
        }

        public async Task<FilteredCourseDto?> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            return course != null ? DtoConverter.MapToFilteredDto(course) : null;
        }

        public async Task<CourseDto?> UpdateAsync(int id, CourseDto data)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course != null)
            {
                course.Name = data.Name;
                course.AuthorId = data.AuthorId;
                course.Description = data.Description;

                await _courseRepository.UpdateAsync();
            }

            return course != null ? DtoConverter.MapToDto(course) : null;
        }
    }
}
