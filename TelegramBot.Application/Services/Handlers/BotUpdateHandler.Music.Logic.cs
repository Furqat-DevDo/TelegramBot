using SpotifyAPI.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Application.Services.CLients;

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

    public async Task SearchMusic(ITelegramBotClient botClient, 
        Message text, 
        CancellationToken cancellationToken)
    {
        var settings = _options.Value ?? throw new ArgumentNullException(nameof(_options));
        var spotifyConfig = SpotifyClientConfig.CreateDefault()
        .WithAuthenticator(
            new ClientCredentialsAuthenticator(settings.ClientId, settings.ClientSecret));

        var spotify = new SpotifyClient(spotifyConfig);

        var searchItems = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, 
            text.Text)
        {
            Limit = 10
        }, cancellationToken);

        


        if (searchItems.Tracks?.Items?.Count <= 0)
        {
            await botClient.SendTextMessageAsync(text.Chat.Id, "No track found.", cancellationToken: cancellationToken);
        }
        else
        {
            
            foreach (var track in searchItems.Tracks?.Items)
            {
                await botClient.SendTextMessageAsync(text.Chat.Id, $"{track.ExternalUrls["spotify"]}",
                    cancellationToken: cancellationToken);
            }
        }
    }

    public async Task DownloadFromYoutube(string Url,ITelegramBotClient bot,long chatId)
    {
        var client = new YouTubeClient();

        var mp3Url = await client.ReturnDownloadLink(Url);

        await bot.SendAudioAsync(
            chatId: chatId,
            audio: InputFile.FromUri(mp3Url));
    }
}