﻿
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandler> _logger;
    public BotUpdateHandler(ILogger<BotUpdateHandler> logger)
    {
        _logger = logger;
    }
    public Task HandlePollingErrorAsync(
        ITelegramBotClient botClient, 
        Exception exception, 
        CancellationToken cancellationToken
        )
    {
        _logger.LogError(exception, "Error while polling for updates");
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(
        ITelegramBotClient botClient, 
        Update update, 
        CancellationToken cancellationToken
        )
    {
        var handler = update.Type switch
        {
            UpdateType.Unknown => throw new NotImplementedException(),
            UpdateType.Message => MessageHandler(botClient, update.Message, cancellationToken),
            UpdateType.InlineQuery => throw new NotImplementedException(),
            UpdateType.ChosenInlineResult => throw new NotImplementedException(),
            UpdateType.CallbackQuery => CallbackQueryHandler(botClient,update?.CallbackQuery,cancellationToken),
            UpdateType.EditedMessage => throw new NotImplementedException(),
            UpdateType.ChannelPost => throw new NotImplementedException(),
            UpdateType.EditedChannelPost => throw new NotImplementedException(),
            UpdateType.ShippingQuery => throw new NotImplementedException(),
            UpdateType.PreCheckoutQuery => throw new NotImplementedException(),
            UpdateType.Poll => throw new NotImplementedException(),
            UpdateType.PollAnswer => throw new NotImplementedException(),
            UpdateType.MyChatMember => throw new NotImplementedException(),
            UpdateType.ChatMember => throw new NotImplementedException(),
            UpdateType.ChatJoinRequest => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };

        try
        {
            await handler;
        }
        catch( Exception exception )
        {
            await HandlePollingErrorAsync(botClient, exception,cancellationToken);    
        }

    }
}
