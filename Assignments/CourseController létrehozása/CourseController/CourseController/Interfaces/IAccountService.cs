using CourseController.Data;
using CourseController.Dtos;

namespace CourseController.Interfaces
{
    public interface IAccountService
    {
        Task<User?> LoginAsync(LoginDto loginDto);
    }
}
