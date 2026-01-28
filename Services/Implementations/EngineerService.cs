using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.DTOs.Engineers;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConstructionBackend1._0.Services.Implementations
{
    public class EngineerService : IEngineerService
    {
        private readonly ConstructionDbContext _context;
        private readonly ILogger<EngineerService> _logger;

        public EngineerService(ConstructionDbContext context, ILogger<EngineerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        //CREATE ENGINEER
        public async Task<User> CreateEngineer(CreateEngineerDto eng)
        {
            _logger.LogInformation("Creating engineer with Email={Email}", eng.Email);

            try
            {
                var newEngineer = new User
                {
                    Role = "Engineer",
                    PhoneNumber = eng.PhoneNumber,
                    Email = eng.Email,
                    FullName = eng.FullName
                };

                _context.Users.Add(newEngineer);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Engineer created successfully with UserId={UserId}", newEngineer.UserId);

                return newEngineer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating engineer with Email={Email}", eng.Email);
                throw;
            }
        }

        //DELETE ENGINEER
        public async Task<bool> DeleteEngineer(int id)
        {
            _logger.LogInformation("Deleting engineer with Id={EngineerId}", id);

            var engineer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Role != null && u.Role.ToLower() == "engineer");

            if (engineer == null)
            {
                _logger.LogWarning("Delete failed. Engineer not found with Id={EngineerId}", id);
                return false;
            }

            _context.Users.Remove(engineer);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Engineer deleted successfully with Id={EngineerId}", id);

            return true;
        }

        //GET ALL ENGINEERS
        public async Task<IEnumerable<User>> GetAllEngineers()
        {
            _logger.LogInformation("Fetching all engineers");

            var engineers = await _context.Users.Where(u => u.Role == "Engineer" || u.Role == "engineer").ToListAsync();

            _logger.LogInformation("Fetched {Count} engineers", engineers.Count);

            return engineers;
        }

        //GET ENGINEER BY ID
        public async Task<User?> GetEngineerById(int id)
        {
            _logger.LogInformation("Fetching engineer with Id={EngineerId}", id);

            var engineer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Role != null && u.Role.ToLower() == "engineer");

            if (engineer == null)
            {
                _logger.LogWarning("Engineer not found with Id={EngineerId}", id);
                return null;
            }

            _logger.LogInformation("Engineer found with Id={EngineerId}", id);

            return engineer;
        }

        //UPDATE ENGINEER
        public async Task<bool> UpdateEngineer(int id, UpdateEngineerDto eng)
        {
            _logger.LogInformation("Updating engineer with Id={EngineerId}", id);

            var engineer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Role != null && u.Role.ToLower() == "engineer");

            if (engineer == null)
            {
                _logger.LogWarning("Update failed. Engineer not found with Id={EngineerId}", id);
                return false;
            }

            engineer.FullName = eng.FullName;
            engineer.Email = eng.Email;
            engineer.PhoneNumber = eng.PhoneNumber;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Engineer updated successfully with Id={EngineerId}", id);

            return true;
        }
    }
}
