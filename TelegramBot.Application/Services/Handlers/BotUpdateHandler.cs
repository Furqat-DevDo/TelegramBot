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

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.StackTrace);
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient,
    Update update,
    CancellationToken cancellationToken)
    {
        var handlers = update.Type switch
        {
            UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
            UpdateType.Unknown => throw new NotImplementedException(),
            UpdateType.InlineQuery => throw new NotImplementedException(),
            UpdateType.ChosenInlineResult => throw new NotImplementedException(),
            UpdateType.CallbackQuery => throw new NotImplementedException(),
            UpdateType.EditedMessage => throw new NotImplementedException(),
            UpdateType.ChannelPost => throw new NotImplementedException(),
            UpdateType.EditedChannelPost => throw new NotImplementedException(),
            UpdateType.ShippingQuery => throw new NotImplementedException(),
            UpdateType.PreCheckoutQuery => throw new NotImplementedException(),
            UpdateType.Poll => throw new NotImplementedException(),
            UpdateType.PollAnswer => throw new NotImplementedException(),
            UpdateType.MyChatMember => HandelMyChatMemeberAsync(botClient, update.Message, cancellationToken),
            UpdateType.ChatMember => throw new NotImplementedException(),
            UpdateType.ChatJoinRequest => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };

        try
        {
            await handlers;
        }
        catch (Exception exception)
        {
            await HandlePollingErrorAsync(botClient, exception, cancellationToken);
        }
    }
}
