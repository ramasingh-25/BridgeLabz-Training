using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;
using FundooApp.RepositoryLayer.Context;
using FundooApp.RepositoryLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundooApp.RepositoryLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FundooDbContext _context;

        public UserRepository(FundooDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(RegistrationDTO registrationDto)
        {
            var user = new User
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                Email = registrationDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
    }
}
