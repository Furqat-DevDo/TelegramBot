using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotKey","");

builder.Services.AddSingleton(new TelegramBotClient(token!));

var app = builder.Build();

app.Run();
