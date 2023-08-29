using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramBot.Core.Entities;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long ChatId { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    DateTimeOffset? UpdatedDate { get; set; } 
    public bool IsDeleted { get; set; } = false;
}
