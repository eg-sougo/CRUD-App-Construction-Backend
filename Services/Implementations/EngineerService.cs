using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.DTOs.Engineers;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstructionBackend1._0.Services.Implementations
{
    public class EngineerService : IEngineerService
    {

        private readonly ConstructionDbContext _context;

        public EngineerService(ConstructionDbContext context)
        {
            _context = context; 
        }



        public async Task<User> CreateEngineer(CreateEngineerDto eng)
        {
            User newEngineer = new User();

            newEngineer.Role = "Engineer";
            newEngineer.PhoneNumber=eng.PhoneNumber;
            newEngineer.Email=eng.Email;
            newEngineer.FullName=eng.FullName;

            _context.Users.Add(newEngineer);
            await _context.SaveChangesAsync();

            return newEngineer;
        }

        public async Task<bool> DeleteEngineer(int id)
        {
            var engineer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Role != null && u.Role.ToLower() == "engineer");

            if (engineer == null)
                return false;
            _context.Users.Remove(engineer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllEngineers()
        {
            var Engineers = await _context.Users.Where(u => u.Role == "Engineer" || u.Role == "engineer").ToListAsync();
            return Engineers;
        }

        public async Task<User?> GetEngineerById(int id)
        {
            var Engineer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Role.ToLower() == "engineer");
            return Engineer;
        }

        public async Task<bool> UpdateEngineer(int id, UpdateEngineerDto eng)
        {
            var engineer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Role != null && u.Role.ToLower() == "engineer");

            if (engineer == null)
            {
                return false;

            }
            engineer.FullName = eng.FullName;
            engineer.Email = eng.Email;
            engineer.PhoneNumber = eng.PhoneNumber;


            await _context.SaveChangesAsync();
            return true;

        }
    }
}
