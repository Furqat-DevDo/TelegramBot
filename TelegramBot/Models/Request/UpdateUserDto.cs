namespace TelegramBot.Models.Request;

public class UpdateUserDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string NickName { get; set; }
    public long ChatId { get; set; }    
}
