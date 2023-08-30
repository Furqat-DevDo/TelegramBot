using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Application.Services;
using TelegramBot.Core.Data;

var builder = WebApplication.CreateBuilder(args);
var token = builder.Configuration.GetValue("BotToken", "");
builder.Services.AddSingleton(new TelegramBotClient(token!));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.AddHostedService<BotBackgroundServica>();


var connectionString = builder.Configuration.GetConnectionString("BotDb");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.Run();
