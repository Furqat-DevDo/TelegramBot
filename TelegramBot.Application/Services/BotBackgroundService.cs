using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBot.Services;

public class BotBackgroundService : BackgroundService
{
    private readonly TelegramBotClient _botClient;
    private readonly ILogger<BotBackgroundService> _logger;
    private readonly IUpdateHandler _updateHandler;

    public BotBackgroundService(
        ILogger<BotBackgroundService> logger,
        TelegramBotClient botClient,
        IUpdateHandler updateHandler)
    {
        _botClient = botClient;
        _logger = logger;
        _updateHandler = updateHandler;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await _botClient.GetMeAsync(stoppingToken);
        _logger.LogInformation(JsonSerializer.Serialize(bot,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }));

        _botClient.StartReceiving(
        _updateHandler.HandleUpdateAsync,
        _updateHandler.HandlePollingErrorAsync,
        new ReceiverOptions
        {
            ThrowPendingUpdates = true
        },
        cancellationToken: stoppingToken);
    }
}