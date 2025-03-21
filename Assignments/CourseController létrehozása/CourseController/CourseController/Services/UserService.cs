using CourseController.Dtos;
using CourseController.Helper;
using CourseController.Interfaces;
using CourseController.Repositories;

namespace CourseController.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(UserDto data)
        {
            if (await _userRepository.EmailExistsAsync(data.Email))
            {
                throw new ArgumentException($"User with Email {data.Email} already exists.");
            }

            await _userRepository.CreateAsync(DtoConverter.MapToModel(data));
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
