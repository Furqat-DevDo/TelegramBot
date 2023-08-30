using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot;

namespace TelegramBot.Application.Services;

public class BotBackgroundServica : BackgroundService
{
    private readonly IUpdateHandler _handler;
    private readonly TelegramBotClient _client;
    private readonly ILogger<BotBackgroundServica> _logger;

    public BotBackgroundServica(
        ILogger<BotBackgroundServica> logger,
        TelegramBotClient client,
        IUpdateHandler handler)
    {
        _handler = handler;
        _client = client;
        _logger = logger;
    }
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        var bot = await _client.GetMeAsync(stoppingToken);
        _logger.LogInformation("Bot started successfully:{bot.Username}", bot.Username);
        _client.StartReceiving(
            _handler.HandleUpdateAsync,
            _handler.HandlePollingErrorAsync,
            new ReceiverOptions()
            {
                ThrowPendingUpdates = true
            }, stoppingToken);
    }
}
