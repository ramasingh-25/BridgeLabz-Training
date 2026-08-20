using FundooApp.ModelLayer.DTOs;

namespace FundooApp.BusinessLayer.Interfaces
{
    public interface INoteBusiness
    {
        Task<NoteResponseDTO> AddNoteAsync(NoteDTO noteDto, int userId);
        Task<IEnumerable<NoteResponseDTO>> GetAllNotesAsync(int userId);
        Task<NoteResponseDTO> UpdateNoteAsync(int noteId, NoteDTO noteDto, int userId);
        Task<bool> DeleteNoteAsync(int noteId, int userId);
    }
}
