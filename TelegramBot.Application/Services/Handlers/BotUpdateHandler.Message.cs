using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task MessageHandlerAsync(
        ITelegramBotClient botClient,
        Message? update,
        CancellationToken cancellationToken,
        bool isEdited = false)
    {
        if (update is not  null)
        {
            var handlers = update.Type switch
            {
                MessageType.Text => TextProcessing(botClient, update, cancellationToken,isEdited),
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
                MessageType.Unknown => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException()
            };

            try
            {
                await handlers;
            }
            catch (Exception e)
            {
                await HandlePollingErrorAsync(botClient,e,cancellationToken);
            }
        }
    }
}
