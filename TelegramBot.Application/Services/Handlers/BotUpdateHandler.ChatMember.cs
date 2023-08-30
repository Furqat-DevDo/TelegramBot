using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.Extensions.Logging;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandelMyChatMemeberAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _logger.LogInformation($"Message recieved from member : {message.From?.FirstName}");
        await botClient.SendTextMessageAsync(message.Chat.Id, $"Welcome back : {message.From?.FirstName}");
    }
}
