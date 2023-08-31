using SpotifyAPI.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Application.Services.Logics;

public static class MusicHandlerLogic
{
    public static  async Task MusicSearcher(
        ITelegramBotClient botClient, 
        Message update, 
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Qo'shiqchi nomini kiriting.",
            cancellationToken:cancellationToken);

    }

    public  static async Task SearchMusic(ITelegramBotClient botClient, Message text, CancellationToken cancellationToken)
    {
        string SPOTIFY_CLIENT_ID = "8bb566b992bd4a559ae7d3eb50e04014";
        string SPOTIFY_CLIENT_SECRET = "ebcb941578824d79bdc31c3fdbbf6f0e";

        var spotifyConfig = SpotifyClientConfig.CreateDefault()
        .WithAuthenticator(
            new ClientCredentialsAuthenticator(SPOTIFY_CLIENT_ID, SPOTIFY_CLIENT_SECRET));

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