using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FundooApp.BusinessLayer.Interfaces;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;
using FundooApp.ModelLayer.Exceptions;
using FundooApp.RepositoryLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FundooApp.BusinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserBusiness(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegistrationDTO registrationDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registrationDto.Email);
            if (existingUser != null)
            {
                throw new InvalidCredentialsException("A user with this email already exists.");
            }

            await _userRepository.RegisterAsync(registrationDto);
            return "Registration successful.";
        }

        public async Task<string> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new InvalidCredentialsException();
            }

            return GenerateJwtToken(user);
        }

        public async Task<UserProfileDTO> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return new UserProfileDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        private string GenerateJwtToken(User user)
        {
            var key = _configuration["Jwt:Key"] ?? "FundooAppSuperSecretKeyForJwtToken123!";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ?? "FundooApp",
                audience: _configuration["Jwt:Audience"] ?? "FundooAppUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
