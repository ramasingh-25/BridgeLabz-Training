namespace FundooNotes.Models.DTOs
{
    public class ReminderMessage
    {
        public long NoteId { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
    }
}
