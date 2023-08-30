namespace TelegramBot.Application.Models;

public class CreateUserDto
{
    public long ChatId { get; set; }
    public String? FullName { get; set; }
    public DateTime Created { get; set; }= DateTime.UtcNow;
}
