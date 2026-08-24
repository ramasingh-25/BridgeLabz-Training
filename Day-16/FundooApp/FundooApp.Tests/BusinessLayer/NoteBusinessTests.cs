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
    public class NoteBusinessTests
    {
        private Mock<INoteRepository> _noteRepositoryMock = null!;
        private NoteBusiness _noteBusiness = null!;
        private const int TestUserId = 1;

        [TestInitialize]
        public void Setup()
        {
            _noteRepositoryMock = new Mock<INoteRepository>();
            _noteBusiness = new NoteBusiness(_noteRepositoryMock.Object);
        }

        // ----- Day 14: Create / Delete -----

        [TestMethod]
        public async Task AddNoteAsync_ShouldReturnCreatedNoteWithMatchingFields()
        {
            // Arrange
            var noteDto = new NoteDTO { Title = "Dotnet", Description = "Day 14 test", Color = "yellow" };

            _noteRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Note>()))
                .ReturnsAsync((Note n) => { n.NoteId = 101; return n; });

            // Act
            var result = await _noteBusiness.AddNoteAsync(noteDto, TestUserId);

            // Assert
            Assert.AreEqual(101, result.NoteId);
            Assert.AreEqual(noteDto.Title, result.Title);
            Assert.AreEqual(noteDto.Description, result.Description);
        }

        [TestMethod]
        public async Task DeleteNoteAsync_WhenNoteExists_ShouldReturnTrue()
        {
            // Arrange
            _noteRepositoryMock.Setup(repo => repo.DeleteAsync(7, TestUserId)).ReturnsAsync(true);

            // Act
            var result = await _noteBusiness.DeleteNoteAsync(7, TestUserId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteNoteAsync_WhenNoteDoesNotExist_ShouldThrowNoteNotFoundException()
        {
            // Arrange
            _noteRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>(), TestUserId)).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<NoteNotFoundException>(
                () => _noteBusiness.DeleteNoteAsync(999, TestUserId));
        }

        // ----- Day 15: Pin / Archive / Trash / Restore -----

        [TestMethod]
        public async Task TogglePinAsync_WhenNoteUnpinned_ShouldSetPinTrue()
        {
            // Arrange
            var note = new Note { NoteId = 1, UserId = TestUserId, IsPin = false };
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(1, TestUserId)).ReturnsAsync(note);
            _noteRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync((Note n) => n);

            // Act
            var result = await _noteBusiness.TogglePinAsync(1, TestUserId);

            // Assert
            Assert.IsTrue(result.IsPin);
        }

        [TestMethod]
        public async Task TogglePinAsync_WhenNotePinned_ShouldSetPinFalse()
        {
            // Arrange
            var note = new Note { NoteId = 1, UserId = TestUserId, IsPin = true };
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(1, TestUserId)).ReturnsAsync(note);
            _noteRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync((Note n) => n);

            // Act
            var result = await _noteBusiness.TogglePinAsync(1, TestUserId);

            // Assert
            Assert.IsFalse(result.IsPin);
        }

        [TestMethod]
        public async Task TogglePinAsync_WhenNoteNotFound_ShouldThrowNoteNotFoundException()
        {
            // Arrange
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), TestUserId)).ReturnsAsync((Note?)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<NoteNotFoundException>(
                () => _noteBusiness.TogglePinAsync(999, TestUserId));
        }

        [TestMethod]
        public async Task ToggleArchiveAsync_ShouldFlipArchiveFlag()
        {
            // Arrange
            var note = new Note { NoteId = 2, UserId = TestUserId, IsArchive = false };
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(2, TestUserId)).ReturnsAsync(note);
            _noteRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync((Note n) => n);

            // Act
            var result = await _noteBusiness.ToggleArchiveAsync(2, TestUserId);

            // Assert
            Assert.IsTrue(result.IsArchive);
        }

        [TestMethod]
        public async Task MoveToTrashAsync_ShouldSetTrashTrueAndUnpin()
        {
            // Arrange - a pinned note being trashed should also lose its pin
            var note = new Note { NoteId = 3, UserId = TestUserId, IsTrash = false, IsPin = true };
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(3, TestUserId)).ReturnsAsync(note);
            _noteRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync((Note n) => n);

            // Act
            var result = await _noteBusiness.MoveToTrashAsync(3, TestUserId);

            // Assert
            Assert.IsTrue(result.IsTrash);
            Assert.IsFalse(result.IsPin);
        }

        [TestMethod]
        public async Task RestoreFromTrashAsync_ShouldSetTrashFalse()
        {
            // Arrange
            var note = new Note { NoteId = 4, UserId = TestUserId, IsTrash = true };
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(4, TestUserId)).ReturnsAsync(note);
            _noteRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Note>())).ReturnsAsync((Note n) => n);

            // Act
            var result = await _noteBusiness.RestoreFromTrashAsync(4, TestUserId);

            // Assert
            Assert.IsFalse(result.IsTrash);
        }

        // ----- Day 15: Search & Filter queries -----

        [TestMethod]
        public async Task GetActiveNotesAsync_ShouldReturnOnlyWhatRepositoryProvides()
        {
            // Arrange
            var notes = new List<Note>
            {
                new() { NoteId = 1, Title = "Active 1", UserId = TestUserId },
                new() { NoteId = 2, Title = "Active 2", UserId = TestUserId }
            };
            _noteRepositoryMock.Setup(repo => repo.GetActiveNotesAsync(TestUserId)).ReturnsAsync(notes);

            // Act
            var result = (await _noteBusiness.GetActiveNotesAsync(TestUserId)).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task SearchNotesAsync_WithBlankQuery_ShouldFallBackToActiveNotes()
        {
            // Arrange - blank search should behave like "show me everything active"
            var notes = new List<Note> { new() { NoteId = 1, Title = "Anything", UserId = TestUserId } };
            _noteRepositoryMock.Setup(repo => repo.GetActiveNotesAsync(TestUserId)).ReturnsAsync(notes);

            // Act
            var result = (await _noteBusiness.SearchNotesAsync(TestUserId, "   ")).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            _noteRepositoryMock.Verify(repo => repo.SearchAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public async Task SearchNotesAsync_WithQuery_ShouldDelegateToRepositorySearch()
        {
            // Arrange
            var notes = new List<Note> { new() { NoteId = 5, Title = "Dotnet Refresher", UserId = TestUserId } };
            _noteRepositoryMock.Setup(repo => repo.SearchAsync(TestUserId, "dotnet")).ReturnsAsync(notes);

            // Act
            var result = (await _noteBusiness.SearchNotesAsync(TestUserId, "dotnet")).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Dotnet Refresher", result[0].Title);
        }

        // ----- Day 16: Labels -----

        [TestMethod]
        public async Task AddLabelToNoteAsync_WhenSuccessful_ShouldReturnUpdatedNote()
        {
            // Arrange
            var noteWithLabel = new Note
            {
                NoteId = 1,
                UserId = TestUserId,
                Title = "Groceries",
                Labels = new List<Label> { new() { LabelId = 2, Name = "Personal" } }
            };
            _noteRepositoryMock.Setup(repo => repo.AddLabelToNoteAsync(1, 2, TestUserId)).ReturnsAsync(true);
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(1, TestUserId)).ReturnsAsync(noteWithLabel);

            // Act
            var result = await _noteBusiness.AddLabelToNoteAsync(1, 2, TestUserId);

            // Assert
            CollectionAssert.Contains(result.Labels, "Personal");
        }

        [TestMethod]
        public async Task AddLabelToNoteAsync_WhenNoteOrLabelMissing_ShouldThrowNoteNotFoundException()
        {
            // Arrange
            _noteRepositoryMock.Setup(repo => repo.AddLabelToNoteAsync(It.IsAny<int>(), It.IsAny<int>(), TestUserId))
                .ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<NoteNotFoundException>(
                () => _noteBusiness.AddLabelToNoteAsync(999, 999, TestUserId));
        }

        [TestMethod]
        public async Task RemoveLabelFromNoteAsync_WhenSuccessful_ShouldReturnUpdatedNote()
        {
            // Arrange
            var noteWithoutLabel = new Note { NoteId = 1, UserId = TestUserId, Title = "Groceries", Labels = new List<Label>() };
            _noteRepositoryMock.Setup(repo => repo.RemoveLabelFromNoteAsync(1, 2, TestUserId)).ReturnsAsync(true);
            _noteRepositoryMock.Setup(repo => repo.GetByIdAsync(1, TestUserId)).ReturnsAsync(noteWithoutLabel);

            // Act
            var result = await _noteBusiness.RemoveLabelFromNoteAsync(1, 2, TestUserId);

            // Assert
            Assert.AreEqual(0, result.Labels.Count);
        }

        [TestMethod]
        public async Task RemoveLabelFromNoteAsync_WhenAssociationMissing_ShouldThrowNoteNotFoundException()
        {
            // Arrange
            _noteRepositoryMock.Setup(repo => repo.RemoveLabelFromNoteAsync(It.IsAny<int>(), It.IsAny<int>(), TestUserId))
                .ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<NoteNotFoundException>(
                () => _noteBusiness.RemoveLabelFromNoteAsync(1, 999, TestUserId));
        }

        [TestMethod]
        public async Task GetNotesByLabelAsync_ShouldReturnOnlyNotesCarryingThatLabel()
        {
            // Arrange
            var notes = new List<Note>
            {
                new() { NoteId = 1, Title = "Tagged", UserId = TestUserId, Labels = new List<Label> { new() { LabelId = 2, Name = "Work" } } }
            };
            _noteRepositoryMock.Setup(repo => repo.GetByLabelAsync(TestUserId, 2)).ReturnsAsync(notes);

            // Act
            var result = (await _noteBusiness.GetNotesByLabelAsync(TestUserId, 2)).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            CollectionAssert.Contains(result[0].Labels, "Work");
        }
    }
}
