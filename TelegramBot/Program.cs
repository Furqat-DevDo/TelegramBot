using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Core.Data;
using TelegramBot.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TelegramBot");


builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(connectionString);
});

var token = builder.Configuration.GetValue("BotKey", "");

builder.Services.AddSingleton(new TelegramBotClient(token!));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.AddHostedService<BackgroundService>();


var app = builder.Build();

app.Run();
