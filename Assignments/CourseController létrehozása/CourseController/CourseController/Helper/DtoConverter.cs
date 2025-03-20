using CourseController.Data;
using CourseController.Dtos;

namespace CourseController.Helper
{
    public class DtoConverter
    {
        // USER
        public static UserDto MapToDto(User user) => new()
        {
            Id = user.Id,
            Name = user.Name,
            Role = user.Role,
            Age = user.Age
        };

        public static User MapToModel(UserDto userDto) => new()
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Role = userDto.Role,
            Age = userDto.Age
        };

        // COURSE
        public static CourseDto MapToDto(Course course) => new()
        {
            Id = course.Id,
            Name = course.Name,
            AuthorId = course.AuthorId,
            Author = course.Author != null ? MapToDto(course.Author) : null,
            Description = course.Description,
        };

        public static Course MapToModel(CourseDto courseDto) => new()
        {
            Id = courseDto.Id,
            Name = courseDto.Name,
            AuthorId = courseDto.AuthorId,
            Description = courseDto.Description
        };
    }
}
