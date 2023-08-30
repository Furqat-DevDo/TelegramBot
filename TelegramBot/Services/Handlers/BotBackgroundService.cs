using System.Text.Json;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBot.Services.Handlers
{
    public class BotBackgroundService : BackgroundService
    {
        private readonly ILogger<BotBackgroundService> _logger;
        private readonly TelegramBotClient _botClient;
        private readonly IUpdateHandler _updatedHandler;

        public BotBackgroundService(ILogger<BotBackgroundService> logger,
                TelegramBotClient botClient,IUpdateHandler updatedHandler)
        {
            _logger = logger;
            _botClient = botClient;
            _updatedHandler = updatedHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bot = await _botClient.GetMeAsync(stoppingToken);
            _logger.LogInformation(JsonSerializer.Serialize(bot,new JsonSerializerOptions
                {
                    WriteIndented = true,
                }));

            _botClient.StartReceiving(
                _updatedHandler.HandleUpdateAsync,
                _updatedHandler.HandlePollingErrorAsync,
                new ReceiverOptions
                {
                    ThrowPendingUpdates = true,
                }, cancellationToken: stoppingToken);
        }
    }
}
