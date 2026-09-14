using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FundooNotes.Models.DTOs;
using FundooNotes.NotesService.Data;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.BackgroundServices
{
    public class ReminderSchedulerService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ReminderSchedulerService> _logger;

        public ReminderSchedulerService(
            IServiceScopeFactory scopeFactory,
            ILogger<ReminderSchedulerService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Reminder Scheduler Background Service is active.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
                    var rabbitMqProducer = scope.ServiceProvider.GetRequiredService<IRabbitMqProducer>();

                    var now = DateTime.UtcNow;

                    // Query for any active notes whose reminder timestamp is now or in the past
                    var dueNotes = await dbContext.Notes
                        .Where(n => n.Reminder != null && n.Reminder <= now && !n.Trash)
                        .ToListAsync(stoppingToken);

                    foreach (var note in dueNotes)
                    {
                        var email = await GetUserEmailAsync(note.UserId, stoppingToken);
                        if (!string.IsNullOrWhiteSpace(email))
                        {
                            var message = new ReminderMessage
                            {
                                NoteId = note.NoteId,
                                UserId = note.UserId,
                                UserEmail = email,
                                Title = note.Title,
                                Description = note.Description,
                                ReminderTime = note.Reminder!.Value
                            };

                            try
                            {
                                await rabbitMqProducer.PublishReminderAsync(message);
                                _logger.LogInformation("Scheduled reminder due for NoteId {NoteId}. Published to RabbitMQ.", note.NoteId);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Failed to publish scheduled reminder for NoteId {NoteId} to RabbitMQ.", note.NoteId);
                            }
                        }

                        // Clear reminder so it does not trigger again in subsequent iterations
                        note.Reminder = null;
                        note.Edited = DateTime.UtcNow;
                    }

                    if (dueNotes.Any())
                    {
                        await dbContext.SaveChangesAsync(stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error checking for due reminders in ReminderSchedulerService.");
                }

                // Check every 15 seconds
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        private async Task<string?> GetUserEmailAsync(int userId, CancellationToken stoppingToken)
        {
            try
            {
                using var client = new HttpClient();
                // Call internal User/Identity Service endpoint
                var response = await client.GetAsync($"http://localhost:5010/api/User/internal/email/{userId}", stoppingToken);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(stoppingToken);
                    using var doc = JsonDocument.Parse(content);
                    if (doc.RootElement.TryGetProperty("email", out var emailProp))
                    {
                        return emailProp.GetString();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling IdentityService to get email for user {UserId}", userId);
            }
            return null;
        }
    }
}
