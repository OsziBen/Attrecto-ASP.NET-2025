using Academy_2025.Data;
using Academy_2025.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2025.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync(); // ha egyből visszaadjuk, felesleges async-await használata ~állapotgép
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();     // FONTOS!
        }

        public Task<int> UpdateAsync()
            => _context.SaveChangesAsync();

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

        public Task<User?> GetByEmailAsync(string email)   // create esetében az egyedi emailre figyelni kell!!!
            => _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
