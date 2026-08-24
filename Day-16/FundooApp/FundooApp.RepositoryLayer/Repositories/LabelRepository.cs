using FundooApp.ModelLayer.Entities;
using FundooApp.RepositoryLayer.Context;
using FundooApp.RepositoryLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundooApp.RepositoryLayer.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly FundooDbContext _context;

        public LabelRepository(FundooDbContext context)
        {
            _context = context;
        }

        public async Task<Label> AddAsync(Label label)
        {
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();
            return label;
        }

        public async Task<IEnumerable<Label>> GetAllByUserAsync(int userId)
        {
            return await _context.Labels
                .Where(l => l.UserId == userId)
                .OrderBy(l => l.Name)
                .ToListAsync();
        }

        public async Task<Label?> GetByIdAsync(int labelId, int userId)
        {
            return await _context.Labels
                .FirstOrDefaultAsync(l => l.LabelId == labelId && l.UserId == userId);
        }

        public async Task<bool> ExistsByNameAsync(int userId, string name)
        {
            return await _context.Labels
                .AnyAsync(l => l.UserId == userId && l.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> DeleteAsync(int labelId, int userId)
        {
            var label = await GetByIdAsync(labelId, userId);
            if (label == null) return false;

            _context.Labels.Remove(label);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
