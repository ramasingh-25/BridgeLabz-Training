using FundooApp.ModelLayer.Entities;

namespace FundooApp.RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        // Commands - create/mutate/delete
        Task<Note> AddAsync(Note note);
        Task<Note> UpdateAsync(Note note);
        Task<bool> DeleteAsync(int noteId, int userId);

        // Queries - read-only, LINQ-filtered (CQRS-style separation)
        Task<Note?> GetByIdAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetAllByUserAsync(int userId);
        Task<IEnumerable<Note>> GetActiveNotesAsync(int userId);
        Task<IEnumerable<Note>> GetArchivedNotesAsync(int userId);
        Task<IEnumerable<Note>> GetTrashedNotesAsync(int userId);
        Task<IEnumerable<Note>> SearchAsync(int userId, string searchTerm);
    }
}
