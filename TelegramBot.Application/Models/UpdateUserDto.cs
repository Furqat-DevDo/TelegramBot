namespace TelegramBot.Application.Models;

public class UpdateUserDto
{
    public long ChatId { get; set; }
    public string? FullName { get; set; }
    public DateTime Created { get; set; }
}
