using FundooApp.ModelLayer.DTOs;

namespace FundooApp.BusinessLayer.Interfaces
{
    public interface INoteBusiness
    {
        // Commands
        Task<NoteResponseDTO> AddNoteAsync(NoteDTO noteDto, int userId);
        Task<NoteResponseDTO> UpdateNoteAsync(int noteId, NoteDTO noteDto, int userId);
        Task<bool> DeleteNoteAsync(int noteId, int userId);
        Task<NoteResponseDTO> TogglePinAsync(int noteId, int userId);
        Task<NoteResponseDTO> ToggleArchiveAsync(int noteId, int userId);
        Task<NoteResponseDTO> MoveToTrashAsync(int noteId, int userId);
        Task<NoteResponseDTO> RestoreFromTrashAsync(int noteId, int userId);
        Task<NoteResponseDTO> AddLabelToNoteAsync(int noteId, int labelId, int userId);
        Task<NoteResponseDTO> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId);

        // Queries
        Task<IEnumerable<NoteResponseDTO>> GetAllNotesAsync(int userId);
        Task<IEnumerable<NoteResponseDTO>> GetActiveNotesAsync(int userId);
        Task<IEnumerable<NoteResponseDTO>> GetArchivedNotesAsync(int userId);
        Task<IEnumerable<NoteResponseDTO>> GetTrashedNotesAsync(int userId);
        Task<IEnumerable<NoteResponseDTO>> SearchNotesAsync(int userId, string searchTerm);
        Task<IEnumerable<NoteResponseDTO>> GetNotesByLabelAsync(int userId, int labelId);
    }
}
