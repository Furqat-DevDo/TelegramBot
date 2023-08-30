using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.Extensions.Logging;

using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.Globalization;

namespace TelegramBot.Application.Services;

public partial class BotUpdateHandler
{
   /* private Dictionary<long, string> userLanguageMap = new Dictionary<long, string>();
    private async Task HandleMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
    {
        if (message?.Text is not { } messageText)
            return;
        var chatId = message.Chat.Id;

        if (message.Text == "/start")
        {
            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
                // first row
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "uz", callbackData: "Uz"),
                    InlineKeyboardButton.WithCallbackData(text: "ru", callbackData: "Ru"),
                },
                // second row
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "en", callbackData: "En"),
                    InlineKeyboardButton.WithCallbackData(text: "turk", callbackData: "Turk"),
                },
            });

            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Kerakli tilni tanlang",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
        else if (message.Text == "uz" || message.Text == "ru" || message.Text == "en" || message.Text == "turk")
        {
            // Foydalanuvchi tanlagan tilni saqlash
            var selectedLanguage = message.Text;
            userLanguageMap[chatId] = selectedLanguage;

            // Tanlagan tilga javob yuborish
            string replyMessage = $"Tanlangan til: {selectedLanguage}";
            await botClient.SendTextMessageAsync(chatId, replyMessage, cancellationToken: cancellationToken);
        }
        else
        {
            // Foydalanuvchining tanlagan tiliga qarab suhbatlashish
            if (userLanguageMap.TryGetValue(chatId, out var selectedLanguage))
            {
                string replyMessage = $"Siz {selectedLanguage} tilida suhbat qilmoqdasiz: {messageText}";
                await botClient.SendTextMessageAsync(chatId, replyMessage, cancellationToken: cancellationToken);
            }
            else
            {
                string replyMessage = "Iltimos, avval tilni tanlang.";
                await botClient.SendTextMessageAsync(chatId, replyMessage, cancellationToken: cancellationToken);
            }
        }
            _logger.LogInformation($"Received a '{messageText}' message in chat {chatId} {message.Audio}.");

        

    }*/

    public async Task HandleUpdatesAsync(ITelegramBotClient telegramBotClient, Update update)
    {
        if (update.Type == UpdateType.Message && update?.Message?.Type is not null)
        {
            await HandleMessageAsync(telegramBotClient, update.Message);
            return;
        }
        if(update.Type==UpdateType.CallbackQuery)
        {
            await HandelCallBackQuary(telegramBotClient,update.Message, update.CallbackQuery);
            return;
        }
    }
    private async Task HandleMessageAsync(ITelegramBotClient client,Message message)
    {
        if(message.Text=="/start")
        {
            await client.SendTextMessageAsync(message.Chat.Id, "chose comandes : /inline | /keyboard");
        }
        if(message.Text=="/keyboard")
        {
            ReplyKeyboardMarkup keyboard = new(new[]
            {
                new KeyboardButton[]{"To'lov qilish","O'tkazmalar"},
                new KeyboardButton[]{"Sozlamalar","Balans"},
            })
            { ResizeKeyboard = true };
            await client.SendTextMessageAsync(message.Chat.Id, "chooce: ", replyMarkup: keyboard);
            return;
        }

        if(message.Text=="/inline")
        {
            InlineKeyboardMarkup keyboard = new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Uz",callbackData:"uz"),
                    InlineKeyboardButton.WithCallbackData("Ru",callbackData:"ru"),
                },

                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Eng",callbackData : "eng"),
                    InlineKeyboardButton.WithCallbackData("Turk",callbackData: "turk"),
                }
            });
            await client.SendTextMessageAsync(message.Chat.Id, "Choose inline keyboard:", replyMarkup: keyboard);
            return;
        }
        await client.SendTextMessageAsync(message.Chat.Id, $"You said:\n{message.Text}");
        
    }


    private async Task HandelCallBackQuary(ITelegramBotClient client,Message message, CallbackQuery calbackquary)
    {

        if (calbackquary.Data=="uz")
        {
            ReplyKeyboardMarkup keyboard = new(new[]
            {
                new KeyboardButton[]{"To'lov qilish","O'tkazmalar"},
                new KeyboardButton[]{"Sozlamalar","Balans"         },
            })
            { ResizeKeyboard = true };
            await client.SendTextMessageAsync(message.Chat.Id, "chooce: ", replyMarkup: keyboard);
            return;
        }
        if (calbackquary.Data==("eng"))
        {
            ReplyKeyboardMarkup keyboard = new(new[]
             {
                new KeyboardButton[]{ "to pay", "transfers"},
                new KeyboardButton[]{"Settings","Balans"},
            })
            { ResizeKeyboard = true };
            await client.SendTextMessageAsync(message.Chat.Id, "chooce: ", replyMarkup: keyboard);
            return;
        }
        if (calbackquary.Data==("ru"))
        {
            ReplyKeyboardMarkup keyboard = new(new[]
            {
                new KeyboardButton[]{"Оплата","Переводы"},
                new KeyboardButton[]{"Настройки", "Баланс"},
            })
            { ResizeKeyboard = true };
            await client.SendTextMessageAsync(message.Chat.Id, "chooce: ", replyMarkup: keyboard);
            return;
        }
        if (calbackquary.Data==("turk"))
        {
            ReplyKeyboardMarkup keyboard = new(new[]
            {
                new KeyboardButton[]{"Оплата","Переводы"},
                new KeyboardButton[]{"Настройки", "Баланс"},
            })
            { ResizeKeyboard = true };
            await client.SendTextMessageAsync(message.Chat.Id, "chooce: ", replyMarkup: keyboard);
            return;
        }

        await client.SendTextMessageAsync(calbackquary.Message.Chat.Id,
                     $"siz tanlagan til:{calbackquary.Data}");
        return;

    }

}
