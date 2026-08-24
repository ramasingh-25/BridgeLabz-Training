using FundooApp.ModelLayer.Entities;
using FundooApp.RepositoryLayer.Context;
using FundooApp.RepositoryLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundooApp.Tests.RepositoryLayer
{
    [TestClass]
    public class LabelRepositoryTests
    {
        private FundooDbContext _context = null!;
        private LabelRepository _labelRepository = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FundooDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new FundooDbContext(options);
            _labelRepository = new LabelRepository(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public async Task AddAsync_ShouldPersistLabelAndAssignId()
        {
            // Arrange
            var label = new Label { Name = "Work", UserId = 1 };

            // Act
            var result = await _labelRepository.AddAsync(label);

            // Assert
            Assert.IsTrue(result.LabelId > 0);
            Assert.AreEqual(1, await _context.Labels.CountAsync());
        }

        [TestMethod]
        public async Task GetAllByUserAsync_ShouldOnlyReturnThatUsersLabels()
        {
            // Arrange
            _context.Labels.AddRange(
                new Label { Name = "Work", UserId = 1 },
                new Label { Name = "Personal", UserId = 1 },
                new Label { Name = "Someone Else's", UserId = 2 }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = (await _labelRepository.GetAllByUserAsync(1)).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task ExistsByNameAsync_WhenNameMatchesCaseInsensitively_ShouldReturnTrue()
        {
            // Arrange
            _context.Labels.Add(new Label { Name = "Work", UserId = 1 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _labelRepository.ExistsByNameAsync(1, "WORK");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ExistsByNameAsync_ForDifferentUser_ShouldReturnFalse()
        {
            // Arrange - same label name, but belongs to a different user
            _context.Labels.Add(new Label { Name = "Work", UserId = 1 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _labelRepository.ExistsByNameAsync(2, "Work");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DeleteAsync_WhenLabelBelongsToUser_ShouldRemoveAndReturnTrue()
        {
            // Arrange
            var label = new Label { Name = "Work", UserId = 1 };
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();

            // Act
            var result = await _labelRepository.DeleteAsync(label.LabelId, 1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, await _context.Labels.CountAsync());
        }

        [TestMethod]
        public async Task DeleteAsync_WhenLabelBelongsToDifferentUser_ShouldReturnFalse()
        {
            // Arrange
            var label = new Label { Name = "Work", UserId = 2 };
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();

            // Act - user 1 tries to delete user 2's label
            var result = await _labelRepository.DeleteAsync(label.LabelId, 1);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, await _context.Labels.CountAsync());
        }
    }
}
