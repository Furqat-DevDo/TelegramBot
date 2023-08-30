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
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://deezerdevs-deezer.p.rapidapi.com/search?q={text.Text}"),
            Headers =
            {
                { "X-RapidAPI-Key", "12627086e7msh4966fd7c187df4bp16e572jsn2f3576ea8b75" },
                { "X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com" },
            },
        };

        using var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        
         // TODO : Change Format or Method
        await botClient.SendTextMessageAsync(text.Chat.Id,
            responseBody, text.MessageId, cancellationToken: cancellationToken);
    }
}