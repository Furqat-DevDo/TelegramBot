using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.Extensions.Logging;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task HandleMessageAsync(ITelegramBotClient botClient,
    Message? message,
    CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _logger.LogInformation("The Message recived from : {0}", message.From?.FirstName);
        await botClient.SendTextMessageAsync(message.Chat.Id,
        $"Siz bizning botdan foydalandingiz {message.From?.FirstName}");
    }
}
