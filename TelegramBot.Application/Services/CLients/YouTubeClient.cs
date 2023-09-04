using System.Text.Json;
using System.Text.Json.Serialization;

namespace TelegramBot.Application.Services.CLients;

public class YouTubeClient : HttpClient
{

    public async Task<string> ReturnDownloadLink(string url)
    {
       var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url+"&quality=320"),
            Headers =
            {
                { "X-RapidAPI-Key", "12627086e7msh4966fd7c187df4bp16e572jsn2f3576ea8b75" },
                { "X-RapidAPI-Host", "youtube-mp3-downloader2.p.rapidapi.com" },
            },
        };

        using var response = await SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var searchResult = JsonSerializer.Deserialize<SearchResult>(body)
            ?? throw new ArgumentNullException();

        return searchResult.Link;
    }
    
}

public class SearchResult
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("link")]
    public required string Link { get; set; }
    
    [JsonPropertyName("length")]
    public required string Length { get; set; }
     
    [JsonPropertyName("size")]
    public required string Size { get; set; }
    
}