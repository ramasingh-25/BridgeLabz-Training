using System.ComponentModel.DataAnnotations;

namespace FundooApp.ModelLayer.DTOs
{
    public class NoteDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Color { get; set; } = "white";

        public DateTime? Reminder { get; set; }
    }

    public class NoteResponseDTO
    {
        public int NoteId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public bool IsPin { get; set; }
        public DateTime? Reminder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
