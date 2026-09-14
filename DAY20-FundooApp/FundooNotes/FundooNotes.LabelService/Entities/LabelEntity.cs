using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.Entities
{
    public class LabelEntity
    {
        [Key]
        public int LabelId { get; set; }

        [Required, MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;

        // Logically relates to UserId in IdentityService and NoteId in NotesService
        public int UserId { get; set; }
        public int NoteId { get; set; }
    }
}
