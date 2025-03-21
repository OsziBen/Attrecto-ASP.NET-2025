using CourseController.Dtos;

namespace CourseController.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(UserDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        Task<List<UserDto>> GetAllAdultUsersAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<FilteredUserDto?> GetFilteredByIdAsync(int id);
        Task<UserDto?> UpdateAsync(int id, UserDto data);
    }
}
