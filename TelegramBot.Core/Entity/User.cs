﻿namespace TelegramBot.Core.Entity;

public class User
{
    public long Id { get; set; }
    public string? UserName { get; set; }
    public long ChatId { get; set; }
    public string? FullName { get; set; }
    public string? PhonNumber { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
