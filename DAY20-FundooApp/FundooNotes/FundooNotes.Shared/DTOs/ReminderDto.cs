using System.ComponentModel.DataAnnotations;

namespace FundooNotes.Models.DTOs
{
    public class ReminderDto
    {
        [Required(ErrorMessage = "Reminder date and time is required.")]
        public DateTime Reminder { get; set; }
    }
}
