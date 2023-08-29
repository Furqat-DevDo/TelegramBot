using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task HandlerMessageAsync(
        ITelegramBotClient botClient,
        Message? update,
        CancellationToken cancellationToken )
    {
        var handlers = update.Type switch
        {
            MessageType.Text => TextProcessing(botClient, update, cancellationToken),
            MessageType.Photo => throw new NotImplementedException(),
            MessageType.Audio => throw new NotImplementedException(),
            MessageType.Video => throw new NotImplementedException(),
            MessageType.Voice => throw new NotImplementedException(),
            MessageType.Document => throw new NotImplementedException(),
            MessageType.Sticker => throw new NotImplementedException(),
            MessageType.Location => throw new NotImplementedException(),
            MessageType.Contact => throw new NotImplementedException(),
            MessageType.Venue => throw new NotImplementedException(),
            MessageType.ChatMembersAdded => throw new NotImplementedException(),
            MessageType.ChatMemberLeft => throw new NotImplementedException(),
            MessageType.ChatTitleChanged => throw new NotImplementedException(),
            MessageType.ChatPhotoChanged => throw new NotImplementedException(),

            MessageType.Unknown => throw new NotImplementedException()
        };
    }
}
