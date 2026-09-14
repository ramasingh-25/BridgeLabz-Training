using FundooNotes.Models.DTOs;

namespace FundooNotes.Service.Interface
{
    public interface IRabbitMqProducer
    {
        Task PublishReminderAsync(ReminderMessage reminderMessage);
    }
}
