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
        private readonly IUserRepository? _userRepository;
        private readonly IRabbitMqProducer? _rabbitMqProducer;
        private readonly ILogger<NoteService>? _logger;

        public NoteService(
            INoteRepository noteRepository,
            IUserRepository? userRepository = null,
            IRabbitMqProducer? rabbitMqProducer = null,
            ILogger<NoteService>? logger = null)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
            _rabbitMqProducer = rabbitMqProducer;
            _logger = logger;
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

            // If reminder was provided during note creation, publish to RabbitMQ
            if (createdNote.Reminder.HasValue && _rabbitMqProducer != null && _userRepository != null)
            {
                try
                {
                    var user = await _userRepository.GetByIdAsync(userId);
                    if (user != null)
                    {
                        var message = new ReminderMessage
                        {
                            NoteId = createdNote.NoteId,
                            UserId = userId,
                            UserEmail = user.Email,
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
            return await _noteRepository.GetAllNotesByUserIdAsync(userId);
        }

        public async Task<bool> DeleteNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.DeleteNoteAsync(noteId, userId);
        }

        public async Task<bool> PinNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.PinNoteAsync(noteId, userId);
        }

        public async Task<bool> ArchiveNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.ArchiveNoteAsync(noteId, userId);
        }

        public async Task<bool> TrashNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.TrashNoteAsync(noteId, userId);
        }

        public async Task<IEnumerable<NotesEntity>> SearchNotesByTitleAsync(string title, int userId)
        {
            return await _noteRepository.SearchNotesByTitleAsync(title, userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetPinnedNotesAsync(int userId)
        {
            return await _noteRepository.GetPinnedNotesAsync(userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetArchivedNotesAsync(int userId)
        {
            return await _noteRepository.GetArchivedNotesAsync(userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetTrashNotesAsync(int userId)
        {
            return await _noteRepository.GetTrashNotesAsync(userId);
        }

        public async Task<bool> SetReminderAsync(long noteId, int userId, DateTime reminder)
        {
            var updated = await _noteRepository.SetReminderAsync(noteId, userId, reminder);
            if (!updated) return false;

            if (_rabbitMqProducer != null && _userRepository != null)
            {
                try
                {
                    var user = await _userRepository.GetByIdAsync(userId);
                    var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);

                    if (user != null && note != null)
                    {
                        var message = new ReminderMessage
                        {
                            NoteId = note.NoteId,
                            UserId = userId,
                            UserEmail = user.Email,
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
            return await _noteRepository.DeleteReminderAsync(noteId, userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetReminderNotesAsync(int userId)
        {
            return await _noteRepository.GetReminderNotesAsync(userId);
        }

        public async Task<bool> SendReminderNotificationAsync(long noteId, int userId)
        {
            if (_rabbitMqProducer == null || _userRepository == null)
            {
                _logger?.LogWarning("RabbitMQ producer or UserRepository not available for sending reminder notification.");
                return false;
            }

            var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            var message = new ReminderMessage
            {
                NoteId = note.NoteId,
                UserId = userId,
                UserEmail = user.Email,
                Title = note.Title,
                Description = note.Description,
                ReminderTime = note.Reminder ?? DateTime.UtcNow
            };

            await _rabbitMqProducer.PublishReminderAsync(message);
            return true;
        }
    }
}