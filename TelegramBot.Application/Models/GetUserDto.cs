namespace TelegramBot.Application.Models;

public class GetUserDto
{
    public long Id { get; set; }
    public string? FullName { get; set; }
    public long ChatId { get; set; }
    public DateTime Created { get; set; }
}
