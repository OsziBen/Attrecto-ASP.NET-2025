using CourseController.Data;
using CourseController.Dtos;
using CourseController.Interfaces;

namespace CourseController.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AccountService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user != null)
            {
                if (_passwordService.VerifyPassword(user.Password, loginDto.Password))
                {
                    return user;
                }
            }

            return null;
        }
    }
}
