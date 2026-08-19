using FundooApp.ModelLayer.DTOs;

namespace FundooApp.BusinessLayer.Interfaces
{
    public interface IUserBusiness
    {
        Task<string> RegisterAsync(RegistrationDTO registrationDto);
        Task<string> LoginAsync(LoginDTO loginDto);
        Task<UserProfileDTO> GetProfileAsync(int userId);
    }
}
