using Microsoft.AspNetCore.Mvc;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userService.RegisterUserAsync(registerDto);
                _logger.LogInformation("User registered successfully: {Email}", user.Email);

                return Ok(new
                {
                    success = true,
                    message = "User registered successfully",
                    data = new { user.UserId, user.FirstName, user.LastName, user.Email }
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Registration failed for {Email}: {Message}", registerDto.Email, ex.Message);
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration for {Email}", registerDto.Email);
                return StatusCode(500, new { success = false, message = "An error occurred during registration.", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userService.LoginUserAsync(loginDto);
                if (user == null)
                {
                    _logger.LogWarning("Failed login attempt for {Email}", loginDto.Email);
                    return Unauthorized(new { success = false, message = "Invalid email or password." });
                }

                var token = _userService.GenerateJwtToken(user);
                _logger.LogInformation("User logged in: {Email}", user.Email);

                return Ok(new
                {
                    success = true,
                    message = "Login successful",
                    token = token,
                    data = new { user.UserId, user.FirstName, user.LastName, user.Email }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during login for {Email}", loginDto.Email);
                return StatusCode(500, new { success = false, message = "An error occurred during login.", error = ex.Message });
            }
        }
    }
}