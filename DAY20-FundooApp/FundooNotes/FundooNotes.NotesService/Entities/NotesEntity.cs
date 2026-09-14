using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models
{
    public class NotesEntity
    {
        [Key]
        public long NoteId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime? Reminder { get; set; }

        [MaxLength(20)]
        public string Backgroundcolor { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Image { get; set; } = string.Empty;

        public bool Pin { get; set; }
        public bool Archive { get; set; }
        public bool Trash { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        // Links note to the user who owns it
        public int UserId { get; set; }
    }
}
