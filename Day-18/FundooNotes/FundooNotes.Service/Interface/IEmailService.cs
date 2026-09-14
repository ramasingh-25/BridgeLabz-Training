namespace FundooNotes.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true);
        Task SendReminderEmailAsync(string toEmail, string noteTitle, string noteDescription, DateTime reminderTime);
    }
}
