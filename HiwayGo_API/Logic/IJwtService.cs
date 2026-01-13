using HiwayGo_API.Entity;

namespace HiwayGo_API.Logic
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}