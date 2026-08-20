using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;

namespace FundooApp.RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(RegistrationDTO registrationDto);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int userId);
    }
}
