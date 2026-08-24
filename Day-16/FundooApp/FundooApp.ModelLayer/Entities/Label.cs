using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundooApp.ModelLayer.Entities
{
    [Table("Labels")]
    public class Label
    {
        [Key]
        public int LabelId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Labels belong to the user who created them (not shared across users)
        [ForeignKey("User")]
        public int UserId { get; set; }

        // Many-to-many: a label can be on many notes, a note can have many labels
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
