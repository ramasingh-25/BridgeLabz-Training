using FundooApp.ModelLayer.DTOs;

namespace FundooApp.BusinessLayer.Interfaces
{
    public interface ILabelBusiness
    {
        Task<LabelResponseDTO> CreateLabelAsync(LabelDTO labelDto, int userId);
        Task<IEnumerable<LabelResponseDTO>> GetAllLabelsAsync(int userId);
        Task<bool> DeleteLabelAsync(int labelId, int userId);
    }
}
