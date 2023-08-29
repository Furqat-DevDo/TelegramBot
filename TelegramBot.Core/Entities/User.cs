using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Core.Entities;
public class User
{
    public long Id { get; set; }
    public string FullName { get; set; } = null;
    public string NickName { get; set; } = null;
    public long ChatId { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public bool IsDeleted { get; set; }
}
