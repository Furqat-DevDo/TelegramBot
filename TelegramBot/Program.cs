using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Application.Services;
using TelegramBot.Application.Services.Handlers;
using TelegramBot.Application.Services.Options;
using TelegramBot.Core.Data;

const string BotKeyConfigKey = "BotKey";
const string DataBaseConfigKey = "DataBase";
const string SpotifyKeys = "Spotify";

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue(BotKeyConfigKey, "");
builder.Services.Configure<SpotifyOptions>(builder.Configuration.GetSection(SpotifyKeys));
builder.Services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(token!));
builder.Services.AddHostedService<BotBackgroundService>();
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

var connection = builder.Configuration.GetConnectionString(DataBaseConfigKey);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(connection);
});

var app = builder.Build();

app.Run();
