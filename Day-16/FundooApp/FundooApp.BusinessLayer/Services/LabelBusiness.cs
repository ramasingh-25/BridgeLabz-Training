using FundooApp.BusinessLayer.Interfaces;
using FundooApp.ModelLayer.DTOs;
using FundooApp.ModelLayer.Entities;
using FundooApp.ModelLayer.Exceptions;
using FundooApp.RepositoryLayer.Interfaces;

namespace FundooApp.BusinessLayer.Services
{
    public class LabelBusiness : ILabelBusiness
    {
        private readonly ILabelRepository _labelRepository;

        public LabelBusiness(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<LabelResponseDTO> CreateLabelAsync(LabelDTO labelDto, int userId)
        {
            var nameExists = await _labelRepository.ExistsByNameAsync(userId, labelDto.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"A label named '{labelDto.Name}' already exists.");
            }

            var label = new Label { Name = labelDto.Name.Trim(), UserId = userId };
            var created = await _labelRepository.AddAsync(label);

            return new LabelResponseDTO { LabelId = created.LabelId, Name = created.Name };
        }

        public async Task<IEnumerable<LabelResponseDTO>> GetAllLabelsAsync(int userId)
        {
            var labels = await _labelRepository.GetAllByUserAsync(userId);
            return labels.Select(l => new LabelResponseDTO { LabelId = l.LabelId, Name = l.Name });
        }

        public async Task<bool> DeleteLabelAsync(int labelId, int userId)
        {
            var deleted = await _labelRepository.DeleteAsync(labelId, userId);
            if (!deleted)
            {
                throw new LabelNotFoundException();
            }
            return true;
        }
    }
}
