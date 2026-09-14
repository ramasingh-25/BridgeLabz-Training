using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundooNotes.Models;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Services;

namespace FundooNotes.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepo = null!;
        private Mock<IConfiguration> _mockConfig = null!;
        private UserService _userService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockUserRepo = new Mock<IUserRepository>();
            _mockConfig = new Mock<IConfiguration>();

            _mockConfig.Setup(c => c["Jwt:Key"]).Returns("SuperSecretKeyThatIsAtLeast32BytesLongForJwtTest!");
            _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("FundooApp");
            _mockConfig.Setup(c => c["Jwt:Audience"]).Returns("FundooUsers");

            _userService = new UserService(_mockUserRepo.Object, _mockConfig.Object);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldRegisterNewUser()
        {
            var registerDto = new UserRegistrationDto
            {
                FirstName = "Jane", LastName = "Doe",
                Email = "jane.doe@example.com", Password = "Password123"
            };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email)).ReturnsAsync((User?)null);

            var createdUser = new User { UserId = 1, FirstName = "Jane", LastName = "Doe", Email = registerDto.Email };
            _mockUserRepo.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(createdUser);

            var result = await _userService.RegisterUserAsync(registerDto);

            Assert.IsNotNull(result);
            Assert.AreEqual("jane.doe@example.com", result.Email);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldThrowException_WhenEmailExists()
        {
            var registerDto = new UserRegistrationDto { Email = "existing@example.com", Password = "Password123" };

            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email))
                         .ReturnsAsync(new User { Email = "existing@example.com" });

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => _userService.RegisterUserAsync(registerDto));
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldCallAddAsync_ExactlyOnce()
        {
            var registerDto = new UserRegistrationDto { Email = "new@example.com", Password = "Password123" };
            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email)).ReturnsAsync((User?)null);
            _mockUserRepo.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(new User { UserId = 2, Email = registerDto.Email });

            await _userService.RegisterUserAsync(registerDto);

            _mockUserRepo.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldPreserveFirstAndLastName()
        {
            var registerDto = new UserRegistrationDto
            {
                FirstName = "Mukesh", LastName = "Kumar", Email = "mk@test.com", Password = "Pass123"
            };
            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email)).ReturnsAsync((User?)null);
            _mockUserRepo.Setup(r => r.AddAsync(It.IsAny<User>()))
                .ReturnsAsync((User u) => u);

            var result = await _userService.RegisterUserAsync(registerDto);

            Assert.AreEqual("Mukesh", result.FirstName);
            Assert.AreEqual("Kumar", result.LastName);
        }

        [TestMethod]
        public async Task LoginUserAsync_ShouldReturnNull_WhenUserNotFound()
        {
            var loginDto = new UserLoginDto { Email = "nonexistent@example.com", Password = "Password123" };
            _mockUserRepo.Setup(r => r.GetByEmailAsync(loginDto.Email)).ReturnsAsync((User?)null);

            var result = await _userService.LoginUserAsync(loginDto);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task LoginUserAsync_ShouldCallGetByEmailAsync_WithCorrectEmail()
        {
            var loginDto = new UserLoginDto { Email = "check@example.com", Password = "Password123" };
            _mockUserRepo.Setup(r => r.GetByEmailAsync(loginDto.Email)).ReturnsAsync((User?)null);

            await _userService.LoginUserAsync(loginDto);

            _mockUserRepo.Verify(r => r.GetByEmailAsync("check@example.com"), Times.Once);
        }

        [TestMethod]
        public void GenerateJwtToken_ShouldReturnNonEmptyTokenString()
        {
            var user = new User { UserId = 1, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" };

            var token = _userService.GenerateJwtToken(user);

            Assert.IsFalse(string.IsNullOrWhiteSpace(token));
        }

        [TestMethod]
        public void GenerateJwtToken_ShouldReturnDifferentTokens_ForDifferentUsers()
        {
            var user1 = new User { UserId = 1, Email = "a@test.com" };
            var user2 = new User { UserId = 2, Email = "b@test.com" };

            var token1 = _userService.GenerateJwtToken(user1);
            var token2 = _userService.GenerateJwtToken(user2);

            Assert.AreNotEqual(token1, token2);
        }

        [TestMethod]
        public void GenerateJwtToken_ShouldContainThreeDotSeparatedParts()
        {
            var user = new User { UserId = 1, Email = "jwt@test.com" };

            var token = _userService.GenerateJwtToken(user);

            var parts = token.Split('.');
            Assert.AreEqual(3, parts.Length);
        }

        [TestMethod]
        public async Task RegisterUserAsync_ShouldThrowException_WithCorrectMessage()
        {
            var registerDto = new UserRegistrationDto { Email = "dupe@test.com", Password = "Password123" };
            _mockUserRepo.Setup(r => r.GetByEmailAsync(registerDto.Email))
                         .ReturnsAsync(new User { Email = "dupe@test.com" });

            try
            {
                await _userService.RegisterUserAsync(registerDto);
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("A user with this email already exists.", ex.Message);
            }
        }
    }
}
