using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task TextProcessing(
        ITelegramBotClient botClient,
        Message? update,
        CancellationToken cancellationToken,
        bool isEdited)
    {
        if (update is null)
            throw new ArgumentNullException(nameof(update));

        LanguageHandler(botClient, update, cancellationToken);

        var chatId = update.Chat.Id;

        if (isEdited)
        {
            await botClient.SendTextMessageAsync(
              chatId,
              $"Siz quyidagi habarni o'zgartirdingiz :{update.Text} {update.MessageId}",
              cancellationToken: cancellationToken);
        }
        else
        {
            await botClient.SendTextMessageAsync(
                chatId,
                $"Salom :{update.From?.Username}",
                cancellationToken: cancellationToken);
        }
        _logger.LogInformation($"Bot Text habarni jo'natdi {update.From?.Username}");
    }
}
