using SpotifyAPI.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Application.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task MusicSearcher(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Qo'shiqchi nomini kiriting.",
            cancellationToken: cancellationToken);

    }

    public async Task SearchMusic(ITelegramBotClient botClient, Message text, CancellationToken cancellationToken)
    {
        var settings = _options.Value ?? throw new ArgumentNullException(nameof(_options));
        var spotifyConfig = SpotifyClientConfig.CreateDefault()
        .WithAuthenticator(
            new ClientCredentialsAuthenticator(settings.ClientId, settings.ClientSecret));

        var spotify = new SpotifyClient(spotifyConfig);

        var searchItems = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, text.Text));


        if (searchItems.Tracks?.Items?.Count <= 0)
        {
            await botClient.SendTextMessageAsync(text.Chat.Id, "No track found.");
        }
        else
        {
            var track = searchItems.Tracks?.Items?[0];
            var responseMessage = $"Track: {track?.Name}, Artist: {track?.Artists[0].Name}, Album: {track?.Album.Name}";
            await botClient.SendTextMessageAsync(text.Chat.Id, responseMessage);
        }
    }
}