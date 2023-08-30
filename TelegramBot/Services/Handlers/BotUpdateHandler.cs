using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBot.Services.Handlers;

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

    public Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Incoming message\n From: {update.Message?.From?.Username}\n" +
            $"Text: {update.Message?.Text}");

        return Task.CompletedTask;
    }
    public async Task HandleUpdateAsync(ITelegramBotClient botClient,
    Update update,
    CancellationToken cancellationToken)
    {
        var handlers = update.Type switch
        {
            Telegram.Bot.Types.Enums.UpdateType.Unknown => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.Message => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.InlineQuery => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.ChosenInlineResult => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.CallbackQuery => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.EditedMessage => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.ChannelPost => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.EditedChannelPost => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.ShippingQuery => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.PreCheckoutQuery => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.Poll => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.PollAnswer => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.MyChatMember => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.ChatMember => throw new NotImplementedException(),
            Telegram.Bot.Types.Enums.UpdateType.ChatJoinRequest => throw new NotImplementedException(),
        };
    }
}
