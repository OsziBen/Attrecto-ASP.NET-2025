using Academy_2025.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2025.Repositories
{
    public class UserRepository
    {
        public static List<User>? Users = new List<User>();
        private readonly ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        // itt nincs actionresult
        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);            
        }
        // nem történik itt már validáció!
        public void Create(User data)
        {
            _context.Users.Add(data);
            _context.SaveChanges();     // FONTOS!
        }

        public User? Update(int id, User data)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                _context.SaveChanges();

                return user;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
