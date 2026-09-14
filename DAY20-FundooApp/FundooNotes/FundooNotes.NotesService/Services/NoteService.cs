using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FundooNotes.Models;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IRabbitMqProducer? _rabbitMqProducer;
        private readonly ILogger<NoteService>? _logger;
        private readonly ICacheService? _cacheService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NoteService(
            INoteRepository noteRepository,
            IHttpContextAccessor httpContextAccessor,
            IRabbitMqProducer? rabbitMqProducer = null,
            ILogger<NoteService>? logger = null,
            ICacheService? cacheService = null)
        {
            _noteRepository = noteRepository;
            _httpContextAccessor = httpContextAccessor;
            _rabbitMqProducer = rabbitMqProducer;
            _logger = logger;
            _cacheService = cacheService;
        }

        private string? GetCurrentUserEmail()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user?.FindFirst(ClaimTypes.Email)?.Value ?? user?.FindFirst("email")?.Value;
        }

        private async Task InvalidateUserNotesCacheAsync(int userId)
        {
            if (_cacheService != null)
            {
                await _cacheService.RemoveAsync($"notes_all_{userId}");
                await _cacheService.RemoveAsync($"notes_pinned_{userId}");
                await _cacheService.RemoveAsync($"notes_archived_{userId}");
                await _cacheService.RemoveAsync($"notes_trash_{userId}");
                await _cacheService.RemoveAsync($"notes_reminders_{userId}");
            }
        }

        public async Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId)
        {
            var note = new NotesEntity
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
                Reminder = noteDto.Reminder,
                Backgroundcolor = noteDto.Backgroundcolor,
                Image = noteDto.Image,
                Pin = noteDto.Pin,
                Archive = noteDto.Archive,
                Trash = false,
                UserId = userId
            };

            var createdNote = await _noteRepository.CreateNoteAsync(note);
            await InvalidateUserNotesCacheAsync(userId);

            // If reminder was provided during note creation, publish to RabbitMQ
            if (createdNote.Reminder.HasValue && _rabbitMqProducer != null)
            {
                try
                {
                    var email = GetCurrentUserEmail();
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        var message = new ReminderMessage
                        {
                            NoteId = createdNote.NoteId,
                            UserId = userId,
                            UserEmail = email,
                            Title = createdNote.Title,
                            Description = createdNote.Description,
                            ReminderTime = createdNote.Reminder.Value
                        };
                        await _rabbitMqProducer.PublishReminderAsync(message);
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogWarning(ex, "Note created with reminder, but failed to publish reminder event to RabbitMQ.");
                }
            }

            return createdNote;
        }

        public async Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId)
        {
            string cacheKey = $"notes_all_{userId}";
            if (_cacheService != null)
            {
                var cachedNotes = await _cacheService.GetAsync<List<NotesEntity>>(cacheKey);
                if (cachedNotes != null)
                {
                    return cachedNotes;
                }
            }

            var notes = (await _noteRepository.GetAllNotesByUserIdAsync(userId)).ToList();
            if (_cacheService != null && notes.Any())
            {
                await _cacheService.SetAsync(cacheKey, notes, TimeSpan.FromMinutes(10));
            }
            return notes;
        }

        public async Task<bool> DeleteNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.DeleteNoteAsync(noteId, userId);
            if (result)
            {
                await InvalidateUserNotesCacheAsync(userId);
            }
            return result;
        }

        public async Task<bool> PinNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.PinNoteAsync(noteId, userId);
            if (result)
            {
                await InvalidateUserNotesCacheAsync(userId);
            }
            return result;
        }

        public async Task<bool> ArchiveNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.ArchiveNoteAsync(noteId, userId);
            if (result)
            {
                await InvalidateUserNotesCacheAsync(userId);
            }
            return result;
        }

        public async Task<bool> TrashNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.TrashNoteAsync(noteId, userId);
            if (result)
            {
                await InvalidateUserNotesCacheAsync(userId);
            }
            return result;
        }

        public async Task<IEnumerable<NotesEntity>> SearchNotesByTitleAsync(string title, int userId)
        {
            return await _noteRepository.SearchNotesByTitleAsync(title, userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetPinnedNotesAsync(int userId)
        {
            string cacheKey = $"notes_pinned_{userId}";
            if (_cacheService != null)
            {
                var cachedNotes = await _cacheService.GetAsync<List<NotesEntity>>(cacheKey);
                if (cachedNotes != null)
                {
                    return cachedNotes;
                }
            }

            var notes = (await _noteRepository.GetPinnedNotesAsync(userId)).ToList();
            if (_cacheService != null && notes.Any())
            {
                await _cacheService.SetAsync(cacheKey, notes, TimeSpan.FromMinutes(10));
            }
            return notes;
        }

        public async Task<IEnumerable<NotesEntity>> GetArchivedNotesAsync(int userId)
        {
            string cacheKey = $"notes_archived_{userId}";
            if (_cacheService != null)
            {
                var cachedNotes = await _cacheService.GetAsync<List<NotesEntity>>(cacheKey);
                if (cachedNotes != null)
                {
                    return cachedNotes;
                }
            }

            var notes = (await _noteRepository.GetArchivedNotesAsync(userId)).ToList();
            if (_cacheService != null && notes.Any())
            {
                await _cacheService.SetAsync(cacheKey, notes, TimeSpan.FromMinutes(10));
            }
            return notes;
        }

        public async Task<IEnumerable<NotesEntity>> GetTrashNotesAsync(int userId)
        {
            string cacheKey = $"notes_trash_{userId}";
            if (_cacheService != null)
            {
                var cachedNotes = await _cacheService.GetAsync<List<NotesEntity>>(cacheKey);
                if (cachedNotes != null)
                {
                    return cachedNotes;
                }
            }

            var notes = (await _noteRepository.GetTrashNotesAsync(userId)).ToList();
            if (_cacheService != null && notes.Any())
            {
                await _cacheService.SetAsync(cacheKey, notes, TimeSpan.FromMinutes(10));
            }
            return notes;
        }

        public async Task<bool> SetReminderAsync(long noteId, int userId, DateTime reminder)
        {
            var updated = await _noteRepository.SetReminderAsync(noteId, userId, reminder);
            if (!updated) return false;

            await InvalidateUserNotesCacheAsync(userId);

            if (_rabbitMqProducer != null)
            {
                try
                {
                    var email = GetCurrentUserEmail();
                    var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);

                    if (!string.IsNullOrWhiteSpace(email) && note != null)
                    {
                        var message = new ReminderMessage
                        {
                            NoteId = note.NoteId,
                            UserId = userId,
                            UserEmail = email,
                            Title = note.Title,
                            Description = note.Description,
                            ReminderTime = reminder
                        };
                        await _rabbitMqProducer.PublishReminderAsync(message);
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogWarning(ex, "Reminder updated in database, but failed to publish event to RabbitMQ.");
                }
            }

            return true;
        }

        public async Task<bool> DeleteReminderAsync(long noteId, int userId)
        {
            var result = await _noteRepository.DeleteReminderAsync(noteId, userId);
            if (result)
            {
                await InvalidateUserNotesCacheAsync(userId);
            }
            return result;
        }

        public async Task<IEnumerable<NotesEntity>> GetReminderNotesAsync(int userId)
        {
            string cacheKey = $"notes_reminders_{userId}";
            if (_cacheService != null)
            {
                var cachedNotes = await _cacheService.GetAsync<List<NotesEntity>>(cacheKey);
                if (cachedNotes != null)
                {
                    return cachedNotes;
                }
            }

            var notes = (await _noteRepository.GetReminderNotesAsync(userId)).ToList();
            if (_cacheService != null && notes.Any())
            {
                await _cacheService.SetAsync(cacheKey, notes, TimeSpan.FromMinutes(10));
            }
            return notes;
        }

        public async Task<bool> SendReminderNotificationAsync(long noteId, int userId)
        {
            if (_rabbitMqProducer == null)
            {
                _logger?.LogWarning("RabbitMQ producer not available for sending reminder notification.");
                return false;
            }

            var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            var email = GetCurrentUserEmail();
            if (string.IsNullOrWhiteSpace(email)) return false;

            var message = new ReminderMessage
            {
                NoteId = note.NoteId,
                UserId = userId,
                UserEmail = email,
                Title = note.Title,
                Description = note.Description,
                ReminderTime = note.Reminder ?? DateTime.UtcNow
            };

            await _rabbitMqProducer.PublishReminderAsync(message);
            return true;
        }
    }
}
