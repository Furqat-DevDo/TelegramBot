namespace TelegramBot.Application.Models.Request;

internal class CreateUser
{
    public long ChatId { get; set; }
    public string? FullName { get; set; }
    public string? PhonNumber { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
