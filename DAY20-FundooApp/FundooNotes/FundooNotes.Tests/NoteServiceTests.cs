using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundooNotes.Models;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;
using FundooNotes.Service.Services;

namespace FundooNotes.Tests
{
    [TestClass]
    public class NoteServiceTests
    {
        private Mock<INoteRepository> _mockRepo = null!;
        private Mock<IHttpContextAccessor> _mockHttpContextAccessor = null!;
        private Mock<IRabbitMqProducer> _mockProducer = null!;
        private NoteService _noteService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<INoteRepository>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            _mockProducer = new Mock<IRabbitMqProducer>();
            _noteService = new NoteService(_mockRepo.Object, _mockHttpContextAccessor.Object, _mockProducer.Object);
        }

        // 1
        [TestMethod]
        public async Task CreateNoteAsync_ShouldReturnCreatedNote()
        {
            int userId = 1;
            var dto = new CreateNoteDto { Title = "My Note", Description = "My Description" };
            var expectedNote = new NotesEntity { NoteId = 10, Title = "My Note", Description = "My Description", UserId = userId };

            _mockRepo.Setup(r => r.CreateNoteAsync(It.IsAny<NotesEntity>())).ReturnsAsync(expectedNote);

            var result = await _noteService.CreateNoteAsync(dto, userId);

            Assert.IsNotNull(result);
            Assert.AreEqual("My Note", result.Title);
            Assert.AreEqual(userId, result.UserId);
        }

        // 2
        [TestMethod]
        public async Task CreateNoteAsync_ShouldSetTrashToFalse_ByDefault()
        {
            int userId = 1;
            var dto = new CreateNoteDto { Title = "Test" };
            NotesEntity? captured = null;

            _mockRepo.Setup(r => r.CreateNoteAsync(It.IsAny<NotesEntity>()))
                     .Callback<NotesEntity>(n => captured = n)
                     .ReturnsAsync((NotesEntity n) => n);

            await _noteService.CreateNoteAsync(dto, userId);

            Assert.IsNotNull(captured);
            Assert.IsFalse(captured!.Trash);
        }

        // 3
        [TestMethod]
        public async Task GetAllNotesAsync_ShouldReturnUserNotes()
        {
            int userId = 1;
            var notes = new List<NotesEntity>
            {
                new NotesEntity { NoteId = 1, Title = "Note 1", UserId = userId },
                new NotesEntity { NoteId = 2, Title = "Note 2", UserId = userId }
            };
            _mockRepo.Setup(r => r.GetAllNotesByUserIdAsync(userId)).ReturnsAsync(notes);

            var result = await _noteService.GetAllNotesAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        // 4
        [TestMethod]
        public async Task GetAllNotesAsync_ShouldReturnEmptyList_WhenNoNotesExist()
        {
            int userId = 99;
            _mockRepo.Setup(r => r.GetAllNotesByUserIdAsync(userId)).ReturnsAsync(new List<NotesEntity>());

            var result = await _noteService.GetAllNotesAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        // 5
        [TestMethod]
        public async Task DeleteNoteAsync_ShouldReturnTrue_WhenDeleted()
        {
            int userId = 1; long noteId = 5;
            _mockRepo.Setup(r => r.DeleteNoteAsync(noteId, userId)).ReturnsAsync(true);

            var result = await _noteService.DeleteNoteAsync(noteId, userId);

            Assert.IsTrue(result);
        }

        // 6
        [TestMethod]
        public async Task DeleteNoteAsync_ShouldReturnFalse_WhenNoteNotFound()
        {
            int userId = 1; long noteId = 999;
            _mockRepo.Setup(r => r.DeleteNoteAsync(noteId, userId)).ReturnsAsync(false);

            var result = await _noteService.DeleteNoteAsync(noteId, userId);

            Assert.IsFalse(result);
        }

        // 7
        [TestMethod]
        public async Task PinNoteAsync_ShouldReturnTrue_WhenPinned()
        {
            int userId = 1; long noteId = 3;
            _mockRepo.Setup(r => r.PinNoteAsync(noteId, userId)).ReturnsAsync(true);

            var result = await _noteService.PinNoteAsync(noteId, userId);

            Assert.IsTrue(result);
        }

        // 8
        [TestMethod]
        public async Task ArchiveNoteAsync_ShouldReturnTrue_WhenArchived()
        {
            int userId = 1; long noteId = 3;
            _mockRepo.Setup(r => r.ArchiveNoteAsync(noteId, userId)).ReturnsAsync(true);

            var result = await _noteService.ArchiveNoteAsync(noteId, userId);

            Assert.IsTrue(result);
        }

        // 9
        [TestMethod]
        public async Task TrashNoteAsync_ShouldReturnTrue_WhenTrashed()
        {
            int userId = 1; long noteId = 3;
            _mockRepo.Setup(r => r.TrashNoteAsync(noteId, userId)).ReturnsAsync(true);

            var result = await _noteService.TrashNoteAsync(noteId, userId);

            Assert.IsTrue(result);
        }

        // 10
        [TestMethod]
        public async Task SearchNotesByTitleAsync_ShouldReturnMatchingNotes()
        {
            int userId = 1;
            var matches = new List<NotesEntity> { new NotesEntity { NoteId = 1, Title = "Meeting notes", UserId = userId } };
            _mockRepo.Setup(r => r.SearchNotesByTitleAsync("Meeting", userId)).ReturnsAsync(matches);

            var result = await _noteService.SearchNotesByTitleAsync("Meeting", userId);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Meeting notes", result.First().Title);
        }

        // 11 - SetReminderAsync Success
        [TestMethod]
        public async Task SetReminderAsync_ShouldReturnTrue_AndPublishToRabbitMq()
        {
            int userId = 1;
            long noteId = 10;
            var reminder = DateTime.UtcNow.AddHours(2);
            var note = new NotesEntity { NoteId = noteId, Title = "Doctor Appointment", Description = "Visit dentist", UserId = userId, Reminder = reminder };

            // Setup mock HttpContext with email claim
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, "test@example.com") };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(c => c.User).Returns(claimsPrincipal);
            _mockHttpContextAccessor.Setup(a => a.HttpContext).Returns(mockHttpContext.Object);

            _mockRepo.Setup(r => r.SetReminderAsync(noteId, userId, reminder)).ReturnsAsync(true);
            _mockRepo.Setup(r => r.GetNoteByIdAsync(noteId, userId)).ReturnsAsync(note);

            var result = await _noteService.SetReminderAsync(noteId, userId, reminder);

            Assert.IsTrue(result);
            _mockProducer.Verify(p => p.PublishReminderAsync(It.Is<ReminderMessage>(m => m.NoteId == noteId && m.UserEmail == "test@example.com")), Times.Once);
        }

        // 12 - SetReminderAsync Note Not Found
        [TestMethod]
        public async Task SetReminderAsync_ShouldReturnFalse_WhenNoteNotFound()
        {
            int userId = 1;
            long noteId = 999;
            var reminder = DateTime.UtcNow.AddHours(2);

            _mockRepo.Setup(r => r.SetReminderAsync(noteId, userId, reminder)).ReturnsAsync(false);

            var result = await _noteService.SetReminderAsync(noteId, userId, reminder);

            Assert.IsFalse(result);
            _mockProducer.Verify(p => p.PublishReminderAsync(It.IsAny<ReminderMessage>()), Times.Never);
        }

        // 13 - DeleteReminderAsync Success
        [TestMethod]
        public async Task DeleteReminderAsync_ShouldReturnTrue_WhenSuccessful()
        {
            int userId = 1;
            long noteId = 10;

            _mockRepo.Setup(r => r.DeleteReminderAsync(noteId, userId)).ReturnsAsync(true);

            var result = await _noteService.DeleteReminderAsync(noteId, userId);

            Assert.IsTrue(result);
        }

        // 14 - DeleteReminderAsync Not Found
        [TestMethod]
        public async Task DeleteReminderAsync_ShouldReturnFalse_WhenNoteNotFound()
        {
            int userId = 1;
            long noteId = 999;

            _mockRepo.Setup(r => r.DeleteReminderAsync(noteId, userId)).ReturnsAsync(false);

            var result = await _noteService.DeleteReminderAsync(noteId, userId);

            Assert.IsFalse(result);
        }

        // 15 - GetReminderNotesAsync
        [TestMethod]
        public async Task GetReminderNotesAsync_ShouldReturnNotesWithReminders()
        {
            int userId = 1;
            var reminderNotes = new List<NotesEntity>
            {
                new NotesEntity { NoteId = 1, Title = "Reminder 1", Reminder = DateTime.UtcNow.AddDays(1), UserId = userId },
                new NotesEntity { NoteId = 2, Title = "Reminder 2", Reminder = DateTime.UtcNow.AddDays(2), UserId = userId }
            };

            _mockRepo.Setup(r => r.GetReminderNotesAsync(userId)).ReturnsAsync(reminderNotes);

            var result = await _noteService.GetReminderNotesAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        // 16 - SendReminderNotificationAsync Success
        [TestMethod]
        public async Task SendReminderNotificationAsync_ShouldReturnTrue_WhenNoteAndUserExist()
        {
            int userId = 1;
            long noteId = 10;
            var note = new NotesEntity { NoteId = noteId, Title = "Doctor Appointment", Description = "Visit dentist", UserId = userId, Reminder = DateTime.UtcNow.AddHours(1) };

            // Setup mock HttpContext with email claim
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, "test@example.com") };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(c => c.User).Returns(claimsPrincipal);
            _mockHttpContextAccessor.Setup(a => a.HttpContext).Returns(mockHttpContext.Object);

            _mockRepo.Setup(r => r.GetNoteByIdAsync(noteId, userId)).ReturnsAsync(note);

            var result = await _noteService.SendReminderNotificationAsync(noteId, userId);

            Assert.IsTrue(result);
            _mockProducer.Verify(p => p.PublishReminderAsync(It.Is<ReminderMessage>(m => m.NoteId == noteId && m.UserEmail == "test@example.com")), Times.Once);
        }

        // 17 - SendReminderNotificationAsync Note Not Found
        [TestMethod]
        public async Task SendReminderNotificationAsync_ShouldReturnFalse_WhenNoteNotFound()
        {
            int userId = 1;
            long noteId = 999;

            _mockRepo.Setup(r => r.GetNoteByIdAsync(noteId, userId)).ReturnsAsync((NotesEntity?)null);

            var result = await _noteService.SendReminderNotificationAsync(noteId, userId);

            Assert.IsFalse(result);
            _mockProducer.Verify(p => p.PublishReminderAsync(It.IsAny<ReminderMessage>()), Times.Never);
        }

        // 18 - GetAllNotesAsync Cache Hit
        [TestMethod]
        public async Task GetAllNotesAsync_ShouldReturnFromCache_WhenCacheHit()
        {
            int userId = 1;
            var mockCache = new Mock<ICacheService>();
            var cachedNotes = new List<NotesEntity>
            {
                new NotesEntity { NoteId = 1, Title = "Cached Note", UserId = userId }
            };

            mockCache.Setup(c => c.GetAsync<List<NotesEntity>>($"notes_all_{userId}"))
                     .ReturnsAsync(cachedNotes);

            var service = new NoteService(_mockRepo.Object, _mockHttpContextAccessor.Object, _mockProducer.Object, cacheService: mockCache.Object);
            var result = await service.GetAllNotesAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Cached Note", result.First().Title);
            _mockRepo.Verify(r => r.GetAllNotesByUserIdAsync(It.IsAny<int>()), Times.Never);
        }

        // 19 - GetAllNotesAsync Cache Miss
        [TestMethod]
        public async Task GetAllNotesAsync_ShouldFetchFromRepoAndSetCache_WhenCacheMiss()
        {
            int userId = 1;
            var mockCache = new Mock<ICacheService>();
            var dbNotes = new List<NotesEntity>
            {
                new NotesEntity { NoteId = 1, Title = "DB Note", UserId = userId }
            };

            mockCache.Setup(c => c.GetAsync<List<NotesEntity>>($"notes_all_{userId}"))
                     .ReturnsAsync((List<NotesEntity>?)null);
            _mockRepo.Setup(r => r.GetAllNotesByUserIdAsync(userId)).ReturnsAsync(dbNotes);

            var service = new NoteService(_mockRepo.Object, _mockHttpContextAccessor.Object, _mockProducer.Object, cacheService: mockCache.Object);
            var result = await service.GetAllNotesAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("DB Note", result.First().Title);
            mockCache.Verify(c => c.SetAsync($"notes_all_{userId}", It.IsAny<List<NotesEntity>>(), It.IsAny<TimeSpan?>()), Times.Once);
        }

        // 20 - CreateNoteAsync Cache Invalidation
        [TestMethod]
        public async Task CreateNoteAsync_ShouldInvalidateCache()
        {
            int userId = 1;
            var mockCache = new Mock<ICacheService>();
            var dto = new CreateNoteDto { Title = "New Note" };
            var createdNote = new NotesEntity { NoteId = 1, Title = "New Note", UserId = userId };

            _mockRepo.Setup(r => r.CreateNoteAsync(It.IsAny<NotesEntity>())).ReturnsAsync(createdNote);

            var service = new NoteService(_mockRepo.Object, _mockHttpContextAccessor.Object, _mockProducer.Object, cacheService: mockCache.Object);
            await service.CreateNoteAsync(dto, userId);

            mockCache.Verify(c => c.RemoveAsync($"notes_all_{userId}"), Times.Once);
            mockCache.Verify(c => c.RemoveAsync($"notes_pinned_{userId}"), Times.Once);
        }
    }
}
