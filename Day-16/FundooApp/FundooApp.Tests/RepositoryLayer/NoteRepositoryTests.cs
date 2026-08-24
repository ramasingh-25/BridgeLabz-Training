using FundooApp.ModelLayer.Entities;
using FundooApp.RepositoryLayer.Context;
using FundooApp.RepositoryLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundooApp.Tests.RepositoryLayer
{
    [TestClass]
    public class NoteRepositoryTests
    {
        private FundooDbContext _context = null!;
        private NoteRepository _noteRepository = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FundooDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new FundooDbContext(options);
            _noteRepository = new NoteRepository(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetActiveNotesAsync_ShouldExcludeArchivedAndTrashedNotes()
        {
            // Arrange
            _context.Notes.AddRange(
                new Note { Title = "Active", UserId = 1, IsArchive = false, IsTrash = false },
                new Note { Title = "Archived", UserId = 1, IsArchive = true, IsTrash = false },
                new Note { Title = "Trashed", UserId = 1, IsArchive = false, IsTrash = true }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.GetActiveNotesAsync(1)).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Active", result[0].Title);
        }

        [TestMethod]
        public async Task GetActiveNotesAsync_ShouldSortPinnedNotesFirst()
        {
            // Arrange
            _context.Notes.AddRange(
                new Note { Title = "Unpinned", UserId = 1, IsPin = false, CreatedAt = DateTime.UtcNow },
                new Note { Title = "Pinned", UserId = 1, IsPin = true, CreatedAt = DateTime.UtcNow.AddMinutes(-5) }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.GetActiveNotesAsync(1)).ToList();

            // Assert - pinned note should come first even though it's older
            Assert.AreEqual("Pinned", result[0].Title);
        }

        [TestMethod]
        public async Task GetArchivedNotesAsync_ShouldOnlyReturnArchivedAndNotTrashed()
        {
            // Arrange
            _context.Notes.AddRange(
                new Note { Title = "Archived Only", UserId = 1, IsArchive = true, IsTrash = false },
                new Note { Title = "Archived And Trashed", UserId = 1, IsArchive = true, IsTrash = true }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.GetArchivedNotesAsync(1)).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Archived Only", result[0].Title);
        }

        [TestMethod]
        public async Task GetTrashedNotesAsync_ShouldReturnAllTrashedRegardlessOfArchiveState()
        {
            // Arrange
            _context.Notes.AddRange(
                new Note { Title = "Trashed Plain", UserId = 1, IsTrash = true },
                new Note { Title = "Trashed From Archive", UserId = 1, IsTrash = true, IsArchive = true }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.GetTrashedNotesAsync(1)).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task SearchAsync_ShouldMatchTitleCaseInsensitively()
        {
            // Arrange
            _context.Notes.AddRange(
                new Note { Title = "Dotnet Refresher", Description = "", UserId = 1 },
                new Note { Title = "Grocery List", Description = "", UserId = 1 }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.SearchAsync(1, "dotnet")).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Dotnet Refresher", result[0].Title);
        }

        [TestMethod]
        public async Task SearchAsync_ShouldMatchDescriptionToo()
        {
            // Arrange
            _context.Notes.Add(new Note { Title = "Untitled", Description = "Pick up milk and eggs", UserId = 1 });
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.SearchAsync(1, "milk")).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public async Task SearchAsync_ShouldExcludeTrashedNotesFromResults()
        {
            // Arrange
            _context.Notes.Add(new Note { Title = "Dotnet Trashed", UserId = 1, IsTrash = true });
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.SearchAsync(1, "dotnet")).ToList();

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        // ----- Day 16: Labels -----

        [TestMethod]
        public async Task AddLabelToNoteAsync_ShouldAttachLabelToNote()
        {
            // Arrange
            var note = new Note { Title = "Groceries", UserId = 1 };
            var label = new Label { Name = "Personal", UserId = 1 };
            _context.Notes.Add(note);
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();

            // Act
            var result = await _noteRepository.AddLabelToNoteAsync(note.NoteId, label.LabelId, 1);

            // Assert
            Assert.IsTrue(result);
            var reloaded = await _noteRepository.GetByIdAsync(note.NoteId, 1);
            Assert.AreEqual(1, reloaded!.Labels.Count);
            Assert.AreEqual("Personal", reloaded.Labels.First().Name);
        }

        [TestMethod]
        public async Task AddLabelToNoteAsync_WhenAlreadyAttached_ShouldNotDuplicateAndStillReturnTrue()
        {
            // Arrange - attaching the same label twice should be idempotent, not create two rows
            var note = new Note { Title = "Groceries", UserId = 1 };
            var label = new Label { Name = "Personal", UserId = 1 };
            _context.Notes.Add(note);
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();

            await _noteRepository.AddLabelToNoteAsync(note.NoteId, label.LabelId, 1);

            // Act
            var result = await _noteRepository.AddLabelToNoteAsync(note.NoteId, label.LabelId, 1);

            // Assert
            Assert.IsTrue(result);
            var reloaded = await _noteRepository.GetByIdAsync(note.NoteId, 1);
            Assert.AreEqual(1, reloaded!.Labels.Count);
        }

        [TestMethod]
        public async Task AddLabelToNoteAsync_WhenLabelBelongsToDifferentUser_ShouldReturnFalse()
        {
            // Arrange
            var note = new Note { Title = "Groceries", UserId = 1 };
            var label = new Label { Name = "Someone Else's Label", UserId = 2 };
            _context.Notes.Add(note);
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();

            // Act
            var result = await _noteRepository.AddLabelToNoteAsync(note.NoteId, label.LabelId, 1);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task RemoveLabelFromNoteAsync_ShouldDetachLabelButKeepLabelItself()
        {
            // Arrange
            var note = new Note { Title = "Groceries", UserId = 1 };
            var label = new Label { Name = "Personal", UserId = 1 };
            note.Labels.Add(label);
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            // Act
            var result = await _noteRepository.RemoveLabelFromNoteAsync(note.NoteId, label.LabelId, 1);

            // Assert
            Assert.IsTrue(result);
            var reloaded = await _noteRepository.GetByIdAsync(note.NoteId, 1);
            Assert.AreEqual(0, reloaded!.Labels.Count);
            Assert.AreEqual(1, await _context.Labels.CountAsync()); // label itself still exists
        }

        [TestMethod]
        public async Task GetByLabelAsync_ShouldReturnOnlyNotesCarryingThatLabel()
        {
            // Arrange
            var label = new Label { Name = "Work", UserId = 1 };
            var taggedNote = new Note { Title = "Tagged", UserId = 1 };
            var untaggedNote = new Note { Title = "Untagged", UserId = 1 };
            taggedNote.Labels.Add(label);
            _context.Notes.AddRange(taggedNote, untaggedNote);
            await _context.SaveChangesAsync();

            // Act
            var result = (await _noteRepository.GetByLabelAsync(1, label.LabelId)).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Tagged", result[0].Title);
        }
    }
}
