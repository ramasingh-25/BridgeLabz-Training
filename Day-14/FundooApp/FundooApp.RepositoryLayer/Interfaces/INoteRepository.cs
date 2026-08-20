using FundooApp.ModelLayer.Entities;

namespace FundooApp.RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> AddAsync(Note note);
        Task<IEnumerable<Note>> GetAllByUserAsync(int userId);
        Task<Note?> GetByIdAsync(int noteId, int userId);
        Task<Note> UpdateAsync(Note note);
        Task<bool> DeleteAsync(int noteId, int userId);
    }
}
