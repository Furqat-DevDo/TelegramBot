namespace TelegramBot.Application.Models.Request;

internal class UpdateUser
{
    public string? FullName { get; set; }
    public string? PhonNumber { get; set; }
    public string? UserName { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
}
