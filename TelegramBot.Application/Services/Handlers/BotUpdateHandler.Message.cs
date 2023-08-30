
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task MessageHandler(
        ITelegramBotClient bot,
        Message? message,
        CancellationToken cancellation)
    {
        if (message?.Text == "/start")
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Uz ", callbackData:"uz"),
                    InlineKeyboardButton.WithCallbackData("Ru", callbackData:"ru")
                },
            });

            await bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Tilni tanlang:\nВыберите язык:",
                replyMarkup: inlineKeyboard
            );
        }
    }

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

            if (callbackQuery.Data == "uz")
            {
                await bot.SendTextMessageAsync(
                    chatId: message.From.Id,
                    text: "Siz uzbek tilini tanladiz!"
                    );
                await MenuBotUz(bot, callbackQuery);
            }
            else
            {
                await bot.SendTextMessageAsync(
                    chatId: message.From.Id,
                    text: "Вы выбрали русский язык!"
                    );
                await MenuBotRu(bot, callbackQuery);
            }
        }
    }
    public async Task MenuBotUz(ITelegramBotClient bot,CallbackQuery message)
    {
        
        var replyKeyboard = new ReplyKeyboardMarkup(new[]
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
            replyMarkup: replyKeyboard
        );
    }

    public async Task MenuBotRu(ITelegramBotClient bot, CallbackQuery message)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(new[]
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
            replyMarkup: replyKeyboard
        );
    }
}

