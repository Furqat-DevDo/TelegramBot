namespace TelegramBot.Application.Models.Request
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string NickName { get; set; }    
        public long ChatId { get; set; }
    }
}
