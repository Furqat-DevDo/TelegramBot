namespace TelegramBot.Application.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public long ChatId { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedTime { get; set; }
}
