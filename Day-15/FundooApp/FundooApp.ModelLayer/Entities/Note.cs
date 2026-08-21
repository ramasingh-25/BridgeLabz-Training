using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundooApp.ModelLayer.Entities
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Color { get; set; } = "white";

        public bool IsArchive { get; set; } = false;

        public bool IsTrash { get; set; } = false;

        public bool IsPin { get; set; } = false;

        public DateTime? Reminder { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedAt { get; set; }

        // Foreign key
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
