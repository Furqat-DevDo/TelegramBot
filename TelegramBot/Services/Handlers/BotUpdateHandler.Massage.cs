using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TelegramBot.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient,
Update update,
CancellationToken cancellationToken)
    {
        var handlers = update

    }
}
