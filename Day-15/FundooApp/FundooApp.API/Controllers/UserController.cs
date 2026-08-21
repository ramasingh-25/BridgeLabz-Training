using System.Security.Claims;
using FundooApp.BusinessLayer.Interfaces;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO registrationDto)
        {
            try
            {
                var message = await _userBusiness.RegisterAsync(registrationDto);
                return Ok(new ResponseDTO<string> { Success = true, Message = message });
            }
            catch (InvalidCredentialsException ex)
            {
                return Conflict(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var token = await _userBusiness.LoginAsync(loginDto);
                return Ok(new ResponseDTO<string> { Success = true, Message = "Login successful.", Data = token });
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }

        // Protected endpoint: requires a valid JWT in the Authorization header.
        // Demonstrates authorization on top of authentication - only a caller
        // with a valid token issued by /login can reach this.
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
                var profile = await _userBusiness.GetProfileAsync(userId);
                return Ok(new ResponseDTO<UserProfileDTO> { Success = true, Message = "Profile fetched.", Data = profile });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
            }
        }
    }
}
