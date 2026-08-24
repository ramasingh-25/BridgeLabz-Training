using FundooApp.ModelLayer.Entities;

namespace FundooApp.RepositoryLayer.Interfaces
{
    public interface ILabelRepository
    {
        Task<Label> AddAsync(Label label);
        Task<IEnumerable<Label>> GetAllByUserAsync(int userId);
        Task<Label?> GetByIdAsync(int labelId, int userId);
        Task<bool> ExistsByNameAsync(int userId, string name);
        Task<bool> DeleteAsync(int labelId, int userId);
    }
}
