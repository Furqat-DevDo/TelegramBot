using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task MenuBotUz(
        ITelegramBotClient bot, 
        CallbackQuery message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
                new []
                {
                    new KeyboardButton("Tilni o'zgartirsh"),
                    new KeyboardButton("Sozlamalar")
                },
                new []
                {
                    new KeyboardButton("Musiqa"),
                    new KeyboardButton("Video")
                }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Kerakli bo'limni tanlang:",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }

    public async Task MenuBotRu(
        ITelegramBotClient bot, 
        CallbackQuery message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
                new []
                {
                    new KeyboardButton("Изменить язык"),
                    new KeyboardButton("Hастройки")
                },
                new []
                {
                    new KeyboardButton("Музыка"),
                    new KeyboardButton("Bидео")
                }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Выберите нужный раздел",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }

    public async Task MenuBotEng(
        ITelegramBotClient bot,
        CallbackQuery message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
                new []
                {
                    new KeyboardButton("Change language"),
                    new KeyboardButton("Settings")
                },
                new []
                {
                    new KeyboardButton("Music"),
                    new KeyboardButton("Video")
                }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Choose needed section:",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );

    }
}
