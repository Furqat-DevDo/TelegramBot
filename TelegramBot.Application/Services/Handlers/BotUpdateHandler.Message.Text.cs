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
                 await botClient.SendAudioAsync(update.Chat.Id, InputFile.FromUri(new Uri("https://ytmp3.savevids.net/dl?hash=9yF02JXd0zAN695lr009d3u7UGFyj1fBu9RvUogvf3CfRC5%2BfYKWdyBuHFDRuLAnSk1T1ggsW7ExDAkpY%2FhKjpaQNrAEx6yCyjjdt%2BkoBKTfzXHUoTCT72F3NmQ%2FmxvtYbZ97J4ZaFOWILU%2B0gQ1b%2B3yyb7SnxrHD8T6KP4qK0SJ4jZVO2dY1W6gG%2BBfgTuHvtz1k%2BYhyC8x8eO6tppWrGFZ61q0DMqF3top59I3Wzgkd1C%2BkKNEoalU5oodtO378W1efPbAJwXMPtF6SWI7ot6DLQBxnKUJKipibgYive7h9MT1IO1hI%2BXqHBEjbT1z")));
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
