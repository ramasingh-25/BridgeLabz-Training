using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            var host = _configuration["Smtp:Host"] ?? "smtp.gmail.com";
            var port = int.TryParse(_configuration["Smtp:Port"], out int p) ? p : 587;
            var enableSsl = bool.TryParse(_configuration["Smtp:EnableSsl"], out bool ssl) ? ssl : true;
            var senderEmail = _configuration["Smtp:SenderEmail"] ?? "no-reply@fundoonotes.com";
            var senderName = _configuration["Smtp:SenderName"] ?? "Fundoo Notes";
            var username = _configuration["Smtp:Username"];
            var password = _configuration["Smtp:Password"];

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };
            mailMessage.To.Add(new MailAddress(toEmail));

            using var smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = enableSsl
            };

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(username, password);
            }

            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendReminderEmailAsync(string toEmail, string noteTitle, string noteDescription, DateTime reminderTime)
        {
            string subject = $"🔔 Reminder: {noteTitle}";
            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f4f6f9; margin: 0; padding: 20px; }}
        .card {{ background-color: #ffffff; max-width: 540px; margin: 0 auto; border-radius: 8px; box-shadow: 0 4px 6px rgba(0,0,0,0.1); overflow: hidden; border: 1px solid #e0e0e0; }}
        .header {{ background-color: #ffbb00; color: #333333; padding: 18px 24px; text-align: center; }}
        .header h2 {{ margin: 0; font-size: 22px; }}
        .content {{ padding: 24px; color: #444444; }}
        .note-box {{ background-color: #fef9e7; border-left: 4px solid #f39c12; padding: 15px; margin: 15px 0; border-radius: 4px; }}
        .note-title {{ font-size: 18px; font-weight: bold; color: #2c3e50; margin-bottom: 8px; }}
        .note-desc {{ font-size: 14px; color: #555555; white-space: pre-wrap; }}
        .time-badge {{ display: inline-block; background-color: #ebf5fb; color: #2980b9; padding: 6px 12px; border-radius: 20px; font-size: 13px; font-weight: 600; margin-top: 10px; }}
        .footer {{ text-align: center; padding: 16px; font-size: 12px; color: #888888; background-color: #fafafa; border-top: 1px solid #eeeeee; }}
    </style>
</head>
<body>
    <div class='card'>
        <div class='header'>
            <h2>Fundoo Notes Reminder</h2>
        </div>
        <div class='content'>
            <p>Hello,</p>
            <p>This is a scheduled reminder for your note:</p>
            <div class='note-box'>
                <div class='note-title'>{System.Net.WebUtility.HtmlEncode(noteTitle)}</div>
                <div class='note-desc'>{System.Net.WebUtility.HtmlEncode(noteDescription)}</div>
                <div class='time-badge'>⏰ Reminder Set For: {reminderTime:yyyy-MM-dd HH:mm:ss} UTC</div>
            </div>
            <p>Stay organized and have a productive day!</p>
        </div>
        <div class='footer'>
            &copy; {DateTime.UtcNow.Year} Fundoo Notes Application
        </div>
    </div>
</body>
</html>";

            await SendEmailAsync(toEmail, subject, body, isHtml: true);
        }
    }
}
