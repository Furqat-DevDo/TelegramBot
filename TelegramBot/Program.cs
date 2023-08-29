using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBot.Core.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TelegramBot");


builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(connectionString);
});

var token = builder.Configuration.GetValue("BotKey", "");

builder.Services.AddSingleton(new TelegramBotClient(token!));

var app = builder.Build();

app.Run();
