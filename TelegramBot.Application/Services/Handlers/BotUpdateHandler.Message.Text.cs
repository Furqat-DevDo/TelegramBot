using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task TextProcessing(
        ITelegramBotClient botClient,
        Message? update,
        CancellationToken cancellationToken)
    {
        if(update is null)
            throw new ArgumentNullException(nameof(update));
        var chatId = update.Chat.Id;

       await  botClient.SendTextMessageAsync(chatId,"Salom");
    }
}
