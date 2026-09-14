using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using FundooNotes.Models.DTOs;
using FundooNotes.Service.Interface;

namespace Fundoo.Api.BackgroundServices
{
    public class RabbitMqReminderConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RabbitMqReminderConsumer> _logger;

        public RabbitMqReminderConsumer(
            IConfiguration configuration,
            IServiceScopeFactory scopeFactory,
            ILogger<RabbitMqReminderConsumer> logger)
        {
            _configuration = configuration;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var queueName = _configuration["RabbitMQ:QueueName"] ?? "fundoo_reminder_queue";
            var hostName = _configuration["RabbitMQ:HostName"] ?? "localhost";
            var port = int.TryParse(_configuration["RabbitMQ:Port"], out int p) ? p : 5672;
            var userName = _configuration["RabbitMQ:UserName"] ?? "guest";
            var password = _configuration["RabbitMQ:Password"] ?? "guest";

            _logger.LogInformation("Starting RabbitMQ Reminder Consumer on queue '{QueueName}' at {HostName}:{Port}...", queueName, hostName, port);

            while (!stoppingToken.IsCancellationRequested)
            {
                IConnection? connection = null;
                IChannel? channel = null;

                try
                {
                    var factory = new ConnectionFactory
                    {
                        HostName = hostName,
                        Port = port,
                        UserName = userName,
                        Password = password,
                        AutomaticRecoveryEnabled = true,
                        NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
                    };

                    connection = await factory.CreateConnectionAsync(stoppingToken);
                    channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

                    await channel.QueueDeclareAsync(
                        queue: queueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null,
                        cancellationToken: stoppingToken);

                    // Set QoS / Prefetch count
                    await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false, cancellationToken: stoppingToken);

                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.ReceivedAsync += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var messageText = Encoding.UTF8.GetString(body);

                        _logger.LogInformation("Received reminder message from RabbitMQ: {Message}", messageText);

                        try
                        {
                            var reminder = JsonSerializer.Deserialize<ReminderMessage>(messageText);
                            if (reminder != null && !string.IsNullOrWhiteSpace(reminder.UserEmail))
                            {
                                using var scope = _scopeFactory.CreateScope();
                                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                                await emailService.SendReminderEmailAsync(
                                    reminder.UserEmail,
                                    reminder.Title,
                                    reminder.Description,
                                    reminder.ReminderTime);

                                _logger.LogInformation("Successfully sent reminder email to {Email} for NoteId {NoteId}", reminder.UserEmail, reminder.NoteId);
                            }

                            if (channel != null && channel.IsOpen)
                            {
                                await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error processing reminder message from RabbitMQ");
                            if (channel != null && channel.IsOpen)
                            {
                                await channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: false);
                            }
                        }
                    };

                    await channel.BasicConsumeAsync(
                        queue: queueName,
                        autoAck: false,
                        consumer: consumer,
                        cancellationToken: stoppingToken);

                    _logger.LogInformation("RabbitMQ Reminder Consumer successfully connected and listening to '{QueueName}'", queueName);

                    while (!stoppingToken.IsCancellationRequested && channel.IsOpen)
                    {
                        await Task.Delay(5000, stoppingToken);
                    }
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("RabbitMQ Reminder Consumer cancellation requested.");
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("RabbitMQ Reminder Consumer could not connect to broker ({HostName}:{Port}): {Message}. Will retry in 15 seconds...", hostName, port, ex.Message);
                }
                finally
                {
                    if (channel != null)
                    {
                        try { await channel.CloseAsync(); } catch { }
                        channel.Dispose();
                    }
                    if (connection != null)
                    {
                        try { await connection.CloseAsync(); } catch { }
                        connection.Dispose();
                    }
                }

                if (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(15000, stoppingToken);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }

            _logger.LogInformation("RabbitMQ Reminder Consumer has stopped.");
        }
    }
}
