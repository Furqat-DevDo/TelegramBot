namespace TelegramBot.Application.Models.Response
{
    public class Dto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public long ChatId { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
