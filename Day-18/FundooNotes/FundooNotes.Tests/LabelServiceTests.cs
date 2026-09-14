using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundooNotes.Models.DTOs;
using FundooNotes.Models.Entities;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Services;

namespace FundooNotes.Tests
{
    [TestClass]
    public class LabelServiceTests
    {
        private Mock<ILabelRepository> _mockRepo = null!;
        private LabelService _labelService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<ILabelRepository>();
            _labelService = new LabelService(_mockRepo.Object);
        }

        // 1
        [TestMethod]
        public async Task AddLabelAsync_ShouldReturnCreatedLabel()
        {
            int userId = 1;
            var dto = new CreateLabelDto { LabelName = "Work", NoteId = 10 };
            var expectedLabel = new LabelEntity { LabelId = 1, LabelName = "Work", NoteId = 10, UserId = userId };

            _mockRepo.Setup(r => r.AddLabelAsync(It.IsAny<LabelEntity>())).ReturnsAsync(expectedLabel);

            var result = await _labelService.AddLabelAsync(dto, userId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Work", result.LabelName);
            Assert.AreEqual(userId, result.UserId);
        }

        // 2
        [TestMethod]
        public async Task AddLabelAsync_ShouldAssociateCorrectNoteId()
        {
            int userId = 1;
            var dto = new CreateLabelDto { LabelName = "Ideas", NoteId = 42 };
            LabelEntity? captured = null;

            _mockRepo.Setup(r => r.AddLabelAsync(It.IsAny<LabelEntity>()))
                     .Callback<LabelEntity>(l => captured = l)
                     .ReturnsAsync((LabelEntity l) => l);

            await _labelService.AddLabelAsync(dto, userId);

            Assert.IsNotNull(captured);
            Assert.AreEqual(42, captured!.NoteId);
        }

        // 3
        [TestMethod]
        public async Task GetLabelByIdAsync_ShouldReturnLabel_WhenExists()
        {
            int userId = 1; int labelId = 5;
            var expectedLabel = new LabelEntity { LabelId = labelId, LabelName = "Personal", UserId = userId };
            _mockRepo.Setup(r => r.GetLabelByIdAsync(labelId, userId)).ReturnsAsync(expectedLabel);

            var result = await _labelService.GetLabelByIdAsync(labelId, userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(labelId, result!.LabelId);
            Assert.AreEqual("Personal", result.LabelName);
        }

        // 4
        [TestMethod]
        public async Task GetLabelByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            int userId = 1; int labelId = 999;
            _mockRepo.Setup(r => r.GetLabelByIdAsync(labelId, userId)).ReturnsAsync((LabelEntity?)null);

            var result = await _labelService.GetLabelByIdAsync(labelId, userId);

            Assert.IsNull(result);
        }

        // 5
        [TestMethod]
        public async Task EditLabelAsync_ShouldReturnUpdatedLabel()
        {
            int userId = 1; int labelId = 2;
            var dto = new UpdateLabelDto { LabelName = "Updated Label" };
            var updatedLabel = new LabelEntity { LabelId = labelId, LabelName = "Updated Label", UserId = userId };

            _mockRepo.Setup(r => r.EditLabelAsync(labelId, dto.LabelName, userId)).ReturnsAsync(updatedLabel);

            var result = await _labelService.EditLabelAsync(labelId, dto, userId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Label", result!.LabelName);
        }

        // 6
        [TestMethod]
        public async Task EditLabelAsync_ShouldReturnNull_WhenLabelNotFound()
        {
            int userId = 1; int labelId = 999;
            var dto = new UpdateLabelDto { LabelName = "Doesn't matter" };
            _mockRepo.Setup(r => r.EditLabelAsync(labelId, dto.LabelName, userId)).ReturnsAsync((LabelEntity?)null);

            var result = await _labelService.EditLabelAsync(labelId, dto, userId);

            Assert.IsNull(result);
        }

        // 7
        [TestMethod]
        public async Task GetAllLabelsAsync_ShouldReturnAllUserLabels()
        {
            int userId = 1;
            var labels = new List<LabelEntity>
            {
                new LabelEntity { LabelId = 1, LabelName = "Home", UserId = userId },
                new LabelEntity { LabelId = 2, LabelName = "Office", UserId = userId }
            };
            _mockRepo.Setup(r => r.GetAllLabelsAsync(userId)).ReturnsAsync(labels);

            var result = await _labelService.GetAllLabelsAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        // 8
        [TestMethod]
        public async Task GetAllLabelsAsync_ShouldReturnEmptyList_WhenNoLabelsExist()
        {
            int userId = 42;
            _mockRepo.Setup(r => r.GetAllLabelsAsync(userId)).ReturnsAsync(new List<LabelEntity>());

            var result = await _labelService.GetAllLabelsAsync(userId);

            Assert.AreEqual(0, result.Count());
        }

        // 9
        [TestMethod]
        public async Task DeleteLabelAsync_ShouldReturnTrue_WhenDeleted()
        {
            int userId = 1; int labelId = 3;
            _mockRepo.Setup(r => r.DeleteLabelAsync(labelId, userId)).ReturnsAsync(true);

            var result = await _labelService.DeleteLabelAsync(labelId, userId);

            Assert.IsTrue(result);
        }

        // 10
        [TestMethod]
        public async Task DeleteLabelAsync_ShouldReturnFalse_WhenLabelNotFound()
        {
            int userId = 1; int labelId = 999;
            _mockRepo.Setup(r => r.DeleteLabelAsync(labelId, userId)).ReturnsAsync(false);

            var result = await _labelService.DeleteLabelAsync(labelId, userId);

            Assert.IsFalse(result);
        }
    }
}