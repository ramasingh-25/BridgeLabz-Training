using FundooApp.BusinessLayer.Services;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;
using FundooApp.ModelLayer.Exceptions;
using FundooApp.RepositoryLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FundooApp.Tests.BusinessLayer
{
    [TestClass]
    public class UserBusinessTests
    {
        private Mock<IUserRepository> _userRepositoryMock = null!;
        private IConfiguration _configuration = null!;
        private UserBusiness _userBusiness = null!;

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            var configValues = new Dictionary<string, string?>
            {
                { "Jwt:Key", "TestSuperSecretKeyForUnitTestsOnly123!" },
                { "Jwt:Issuer", "FundooApp" },
                { "Jwt:Audience", "FundooAppUsers" }
            };
            _configuration = new ConfigurationBuilder().AddInMemoryCollection(configValues).Build();

            _userBusiness = new UserBusiness(_userRepositoryMock.Object, _configuration);
        }

        [TestMethod]
        public async Task RegisterAsync_WhenEmailDoesNotExist_ShouldRegisterSuccessfully()
        {
            // Arrange
            var registrationDto = new RegistrationDTO
            {
                FirstName = "Rama",
                LastName = "Singh",
                Email = "rama.singh@example.com",
                Password = "Password@123"
            };

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(registrationDto.Email))
                .ReturnsAsync((User?)null);
            _userRepositoryMock.Setup(repo => repo.RegisterAsync(registrationDto))
                .ReturnsAsync(new User { UserId = 1, Email = registrationDto.Email });

            // Act
            var result = await _userBusiness.RegisterAsync(registrationDto);

            // Assert
            Assert.AreEqual("Registration successful.", result);
            _userRepositoryMock.Verify(repo => repo.RegisterAsync(registrationDto), Times.Once);
        }

        [TestMethod]
        public async Task RegisterAsync_WhenEmailAlreadyExists_ShouldThrowInvalidCredentialsException()
        {
            // Arrange
            var registrationDto = new RegistrationDTO
            {
                FirstName = "Rama",
                LastName = "Singh",
                Email = "existing@example.com",
                Password = "Password@123"
            };

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(registrationDto.Email))
                .ReturnsAsync(new User { Email = registrationDto.Email });

            // Act & Assert
            await Assert.ThrowsExceptionAsync<InvalidCredentialsException>(
                () => _userBusiness.RegisterAsync(registrationDto));
        }

        [TestMethod]
        public async Task LoginAsync_WithValidCredentials_ShouldReturnJwtToken()
        {
            // Arrange
            var plainPassword = "Password@123";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

            var loginDto = new LoginDTO { Email = "rama.singh@example.com", Password = plainPassword };
            var existingUser = new User
            {
                UserId = 1,
                Email = loginDto.Email,
                FirstName = "Rama",
                LastName = "Singh",
                Password = hashedPassword
            };

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(loginDto.Email))
                .ReturnsAsync(existingUser);

            // Act
            var token = await _userBusiness.LoginAsync(loginDto);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(token));
            Assert.AreEqual(3, token.Split('.').Length); // JWT = header.payload.signature
        }

        [TestMethod]
        public async Task LoginAsync_WithWrongPassword_ShouldThrowInvalidCredentialsException()
        {
            // Arrange
            var loginDto = new LoginDTO { Email = "rama.singh@example.com", Password = "WrongPassword" };
            var existingUser = new User
            {
                Email = loginDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword("CorrectPassword@123")
            };

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(loginDto.Email))
                .ReturnsAsync(existingUser);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<InvalidCredentialsException>(
                () => _userBusiness.LoginAsync(loginDto));
        }

        [TestMethod]
        public async Task LoginAsync_WithNonExistentUser_ShouldThrowInvalidCredentialsException()
        {
            // Arrange
            var loginDto = new LoginDTO { Email = "doesnotexist@example.com", Password = "Password@123" };

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(loginDto.Email))
                .ReturnsAsync((User?)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<InvalidCredentialsException>(
                () => _userBusiness.LoginAsync(loginDto));
        }

        [TestMethod]
        public async Task GetProfileAsync_WhenUserExists_ShouldReturnProfile()
        {
            // Arrange
            var user = new User
            {
                UserId = 1,
                FirstName = "Rama",
                LastName = "Singh",
                Email = "rama.singh@example.com",
                CreatedAt = new DateTime(2026, 1, 1)
            };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var profile = await _userBusiness.GetProfileAsync(1);

            // Assert
            Assert.AreEqual("Rama", profile.FirstName);
            Assert.AreEqual("rama.singh@example.com", profile.Email);
        }

        [TestMethod]
        public async Task GetProfileAsync_WhenUserDoesNotExist_ShouldThrowUserNotFoundException()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((User?)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<UserNotFoundException>(
                () => _userBusiness.GetProfileAsync(999));
        }
    }
}
