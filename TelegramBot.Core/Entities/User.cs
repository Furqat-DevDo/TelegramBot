namespace TelegramBot.Core.Entities;

public class User
{
    public long Id { get; set; }
    public string? FullName { get; set; }
    public long ChatId { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}
