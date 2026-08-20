using FundooApp.ModelLayer.Entities;
using FundooApp.RepositoryLayer.Context;
using FundooApp.RepositoryLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundooApp.RepositoryLayer.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly FundooDbContext _context;

        public NoteRepository(FundooDbContext context)
        {
            _context = context;
        }

        public async Task<Note> AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<IEnumerable<Note>> GetAllByUserAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && !n.IsTrash)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(int noteId, int userId)
        {
            return await _context.Notes
                .FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);
        }

        public async Task<Note> UpdateAsync(Note note)
        {
            note.ModifiedAt = DateTime.UtcNow;
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeleteAsync(int noteId, int userId)
        {
            var note = await GetByIdAsync(noteId, userId);
            if (note == null) return false;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
