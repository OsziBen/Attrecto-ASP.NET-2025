using BCrypt.Net;
using CourseController.Dtos;
using CourseController.Helper;
using CourseController.Interfaces;
using CourseController.Repositories;

namespace CourseController.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task CreateAsync(UserDto data)
        {
            if (await _userRepository.EmailExistsAsync(data.Email))
            {
                throw new ArgumentException($"User with Email {data.Email} already exists.");
            }

            var hashedPassword = _passwordService.HashPassword(data.Password);

            var user = DtoConverter.MapToModel(data);
            user.Password = hashedPassword;

            await _userRepository.CreateAsync(user);
        }


        public Task<bool> DeleteAsync(int id)
            => _userRepository.DeleteAsync(id);

        public async Task<List<UserDto>> GetAllAdultUsersAsync()
        {
            var adultUsers = await _userRepository.GetAllAdultUsersAsync();

            return adultUsers.Select(DtoConverter.MapToDto).ToList();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(DtoConverter.MapToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user != null ? DtoConverter.MapToDto(user) : null;
        }

        public async Task<UserDto?> UpdateAsync(int id, UserDto data)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user != null)
            {
                user.Name = data.Name;
                user.Role = data.Role;
                user.Age = data.Age;

                await _userRepository.UpdateAsync();
            }

            return user != null ? DtoConverter.MapToDto(user) : null;
        }
    }
}
