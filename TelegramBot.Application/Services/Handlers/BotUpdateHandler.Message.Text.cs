using Telegram.Bot.Types;
using Telegram.Bot;

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

        Task? tasks;
        switch (update.Text)
        {
            
            case "/start" or "Tilni o'zgartirsh" or "Изменить язык" or "Change language":
                tasks = LanguageHandler(botClient, update, cancellationToken);
                break;
            case "Music\ud83c\udfbc" or "Музыка\ud83c\udfbc" or "Musiqa\ud83c\udfbc":
                tasks = MusicSearcher(botClient, update, cancellationToken);
                break;

             default:
                 tasks = Task.CompletedTask;
                 break;
        }

        if (update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("nomini kiriting."))
        {
            await SearchMusic(botClient, update, cancellationToken);
        }

        try
        {
            await tasks;
        }
        catch (Exception e)
        {
            await HandlePollingErrorAsync(botClient, e, cancellationToken);
        }
    }
}
