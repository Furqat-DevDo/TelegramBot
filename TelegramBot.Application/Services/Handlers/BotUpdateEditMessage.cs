using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Application.Services;

public partial class BotUpdateHandler
{
    private Dictionary<long, string> userLanguageMap = new Dictionary<long, string>();
    private async Task HandleEditMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
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
        
        _logger.LogInformation($"Received a '{messageText}' message in chat {chatId} {message.Text}.");



    }

  /*  private async Task HandleEditMessageAsync(ITelegramBotClient botClient, Message? message, CancellationToken cancellationToken)
    {
        if (message?.Text is not { } messageText)
            return;
        var chatId = message.Chat.Id;

        if (message.Text != "/start")
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
      
        _logger.LogInformation($"Received a '{messageText}' message in chat {chatId} {message.Audio}.");



    }
*/
   

    
}
