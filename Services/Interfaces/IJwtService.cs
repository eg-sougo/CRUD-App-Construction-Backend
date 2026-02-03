using ConstructionBackend1._0.Models;

namespace ConstructionBackend1._0.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
