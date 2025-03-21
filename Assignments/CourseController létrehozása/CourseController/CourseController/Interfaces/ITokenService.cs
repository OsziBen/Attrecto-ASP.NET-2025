using CourseController.Data;

namespace CourseController.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
