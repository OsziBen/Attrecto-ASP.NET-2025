using CourseController.Data;
using CourseController.Dtos;
using CourseController.Interfaces;

namespace CourseController.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user != null && user.Password == loginDto.Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
