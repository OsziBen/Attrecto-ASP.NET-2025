using CourseController.Data;

namespace CourseController.Interfaces
{
    public interface IUserRepository
    {
        void Create(User data);
        bool Delete(int id);
        List<User> GetAll();
        List<User> GetAllAdultUsers();
        User? GetById(int id);
        User? Update(int id, User data);
    }
}