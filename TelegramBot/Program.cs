using Microsoft.EntityFrameworkCore;
using TelegramBot.Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql("DataBase");
});

var app = builder.Build();

app.Run();
