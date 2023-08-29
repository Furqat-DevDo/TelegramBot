namespace TelegramBot.Application.DTOs;

public class CreateUserDto
{
    public required long ChatId { get; set; }
    public string? FullName { get; set; }
    public required string UserName { get; set; }
}
