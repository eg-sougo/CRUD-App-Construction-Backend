using ConstructionBackend1._0.DTOs.Engineers;
using ConstructionBackend1._0.Models;

namespace ConstructionBackend1._0.Services.Interfaces
{
    public interface IEngineerService
    {
        Task<IEnumerable<User>> GetAllEngineers();
        Task<User?> GetEngineerById(int id);
        Task<User> CreateEngineer(CreateEngineerDto eng);
        Task<bool> UpdateEngineer(int id, UpdateEngineerDto eng);
        Task<bool> DeleteEngineer(int id);
    }
}
