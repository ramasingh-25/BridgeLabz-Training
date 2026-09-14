using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RabbitMqProducer> _logger;

        public RabbitMqProducer(IConfiguration configuration, ILogger<RabbitMqProducer> _logger)
        {
            this._configuration = configuration;
            this._logger = _logger;
        }

        public async Task PublishReminderAsync(ReminderMessage reminderMessage)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _configuration["RabbitMQ:HostName"] ?? "localhost",
                    Port = int.TryParse(_configuration["RabbitMQ:Port"], out int p) ? p : 5672,
                    UserName = _configuration["RabbitMQ:UserName"] ?? "guest",
                    Password = _configuration["RabbitMQ:Password"] ?? "guest"
                };

                var queueName = _configuration["RabbitMQ:QueueName"] ?? "fundoo_reminder_queue";

                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var json = JsonSerializer.Serialize(reminderMessage);
                var body = Encoding.UTF8.GetBytes(json);

                var properties = new BasicProperties
                {
                    Persistent = true
                };

                await channel.BasicPublishAsync(
                    exchange: string.Empty,
                    routingKey: queueName,
                    mandatory: false,
                    basicProperties: properties,
                    body: body);

                _logger.LogInformation("Successfully published reminder message for NoteId {NoteId} to RabbitMQ queue '{QueueName}'", reminderMessage.NoteId, queueName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to publish reminder message for NoteId {NoteId} to RabbitMQ", reminderMessage.NoteId);
                throw;
            }
        }
    }
}
