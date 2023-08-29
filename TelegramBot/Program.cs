using Microsoft.EntityFrameworkCore;
using TelegramBot.Core.Data;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(connection);
});

var app = builder.Build();

app.Run();
