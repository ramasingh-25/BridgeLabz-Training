using FundooApp.BusinessLayer.Services;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;
using FundooApp.ModelLayer.Exceptions;
using FundooApp.RepositoryLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FundooApp.Tests.BusinessLayer
{
    [TestClass]
    public class LabelBusinessTests
    {
        private Mock<ILabelRepository> _labelRepositoryMock = null!;
        private LabelBusiness _labelBusiness = null!;
        private const int TestUserId = 1;

        [TestInitialize]
        public void Setup()
        {
            _labelRepositoryMock = new Mock<ILabelRepository>();
            _labelBusiness = new LabelBusiness(_labelRepositoryMock.Object);
        }

        [TestMethod]
        public async Task CreateLabelAsync_WhenNameIsUnique_ShouldCreateLabel()
        {
            // Arrange
            var labelDto = new LabelDTO { Name = "Work" };
            _labelRepositoryMock.Setup(repo => repo.ExistsByNameAsync(TestUserId, "Work")).ReturnsAsync(false);
            _labelRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Label>()))
                .ReturnsAsync((Label l) => { l.LabelId = 10; return l; });

            // Act
            var result = await _labelBusiness.CreateLabelAsync(labelDto, TestUserId);

            // Assert
            Assert.AreEqual(10, result.LabelId);
            Assert.AreEqual("Work", result.Name);
        }

        [TestMethod]
        public async Task CreateLabelAsync_WhenNameAlreadyExists_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var labelDto = new LabelDTO { Name = "Work" };
            _labelRepositoryMock.Setup(repo => repo.ExistsByNameAsync(TestUserId, "Work")).ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => _labelBusiness.CreateLabelAsync(labelDto, TestUserId));
        }

        [TestMethod]
        public async Task CreateLabelAsync_ShouldTrimWhitespaceFromName()
        {
            // Arrange
            var labelDto = new LabelDTO { Name = "  Personal  " };
            _labelRepositoryMock.Setup(repo => repo.ExistsByNameAsync(TestUserId, "  Personal  ")).ReturnsAsync(false);
            _labelRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Label>()))
                .ReturnsAsync((Label l) => l);

            // Act
            var result = await _labelBusiness.CreateLabelAsync(labelDto, TestUserId);

            // Assert
            Assert.AreEqual("Personal", result.Name);
        }

        [TestMethod]
        public async Task GetAllLabelsAsync_ShouldReturnAllLabelsForUser()
        {
            // Arrange
            var labels = new List<Label>
            {
                new() { LabelId = 1, Name = "Work", UserId = TestUserId },
                new() { LabelId = 2, Name = "Personal", UserId = TestUserId }
            };
            _labelRepositoryMock.Setup(repo => repo.GetAllByUserAsync(TestUserId)).ReturnsAsync(labels);

            // Act
            var result = (await _labelBusiness.GetAllLabelsAsync(TestUserId)).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEquivalent(new[] { "Work", "Personal" }, result.Select(l => l.Name).ToList());
        }

        [TestMethod]
        public async Task DeleteLabelAsync_WhenLabelExists_ShouldReturnTrue()
        {
            // Arrange
            _labelRepositoryMock.Setup(repo => repo.DeleteAsync(5, TestUserId)).ReturnsAsync(true);

            // Act
            var result = await _labelBusiness.DeleteLabelAsync(5, TestUserId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteLabelAsync_WhenLabelDoesNotExist_ShouldThrowLabelNotFoundException()
        {
            // Arrange
            _labelRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>(), TestUserId)).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<LabelNotFoundException>(
                () => _labelBusiness.DeleteLabelAsync(999, TestUserId));
        }
    }
}
