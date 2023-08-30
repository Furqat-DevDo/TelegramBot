using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Application.Services;
using TelegramBot.Application.Services.Handlers;
using TelegramBot.Core.Data;

var builder = WebApplication.CreateBuilder(args);


var token = builder.Configuration.GetValue("BotKey", "");
builder.Services.AddSingleton(new TelegramBotClient(token!));

builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

builder.Services.AddHostedService<BotBackgroundService>();

var connectionString = builder.Configuration.GetConnectionString("UserDb");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.Run();
