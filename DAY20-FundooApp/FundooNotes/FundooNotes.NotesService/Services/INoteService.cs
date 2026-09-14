using FundooNotes.Models;
using FundooNotes.Models.DTOs;

namespace FundooNotes.Service.Interface
{
    public interface INoteService
    {
        Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId);
        Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId);
        Task<bool> DeleteNoteAsync(long noteId, int userId);

        Task<bool> PinNoteAsync(long noteId, int userId);
        Task<bool> ArchiveNoteAsync(long noteId, int userId);
        Task<bool> TrashNoteAsync(long noteId, int userId);

        Task<IEnumerable<NotesEntity>> SearchNotesByTitleAsync(string title, int userId);
        Task<IEnumerable<NotesEntity>> GetPinnedNotesAsync(int userId);
        Task<IEnumerable<NotesEntity>> GetArchivedNotesAsync(int userId);
        Task<IEnumerable<NotesEntity>> GetTrashNotesAsync(int userId);

        Task<bool> SetReminderAsync(long noteId, int userId, DateTime reminder);
        Task<bool> DeleteReminderAsync(long noteId, int userId);
        Task<IEnumerable<NotesEntity>> GetReminderNotesAsync(int userId);
        Task<bool> SendReminderNotificationAsync(long noteId, int userId);
    }
}
