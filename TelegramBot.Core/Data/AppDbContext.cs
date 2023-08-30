using Microsoft.EntityFrameworkCore;
using TelegramBot.Core.Entities;

namespace TelegramBot.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>Users { get; set; }
}
