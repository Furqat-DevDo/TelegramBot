namespace TelegramBot.Application.DTOs;

public class UpdateUserDto
{
    public long Id { get; set; }
    public string? FullName { get; set; }
    public required string UserName { get; set; }
}
