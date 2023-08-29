using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Application.Services;
using TelegramBot.Application.Services.Handlers;
using TelegramBot.Core.Data;


var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotKey", "");

builder.Services.AddSingleton(new TelegramBotClient(token!));
builder.Services.AddHostedService<BotBackgroundService>();
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

var connection = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(connection);
});

var app = builder.Build();

app.Run();
