using CourseController.Data;
using CourseController.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseController.Repositories
{
    public class UserRepository : IUserRepository
    {
        //public static List<User>? Users = new List<User>();
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> UpdateAsync(int id, User data)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.Name = data.Name;
                user.Role = data.Role;
                user.Age = data.Age;
                await _context.SaveChangesAsync();

                return user;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public Task<List<User>> GetAllAdultUsersAsync()
        {
            return _context.Users.Where(x => x.Age >= 18).ToListAsync();
        }
    }
}
