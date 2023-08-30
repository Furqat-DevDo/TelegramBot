using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task CallbackQueryHandler(
        ITelegramBotClient bot,
        CallbackQuery message,
        CancellationToken cancellation)
    {
        {
            CallbackQuery callbackQuery = message;
            await bot.AnswerCallbackQueryAsync(
                callbackQuery.Id,
                $"Received {callbackQuery.Data}"
            );

            switch (callbackQuery.Data)
            {
                case "uz":
                    await bot.SendTextMessageAsync(
                        chatId: message.From.Id,
                        text: "Siz uzbek tilini tanladiz!"
                        );
                    await MenuBotUz(bot, callbackQuery, cancellation);
                    break;

                case "ru":
                    await bot.SendTextMessageAsync(
                        chatId: message.From.Id,
                        text: "Вы выбрали русский язык!"
                        );
                    await MenuBotRu(bot, callbackQuery, cancellation);
                    break;
                case "eng":
                    await bot.SendTextMessageAsync(
                        chatId: message.From.Id,
                        text: "You have chosen English!"
                        );
                    await MenuBotEng(bot, callbackQuery, cancellation);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        await Task.FromCanceled(cancellation);
    }
}
