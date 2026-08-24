using System.ComponentModel.DataAnnotations;

namespace FundooApp.ModelLayer.DTOs
{
    public class LabelDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }

    public class LabelResponseDTO
    {
        public int LabelId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
