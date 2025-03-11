using Academy_2025.Data;

namespace Academy_2025.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
