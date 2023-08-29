using TelegramBot.Application.DTOs;
using TelegramBot.Core.Entities;

namespace TelegramBot.Application.Extensions;

public static class Extensions
{
    public static User UserCreate(this CreateUserDto dto)
        => new User
        {
            ChatId = dto.ChatId,
            FullName = dto.FullName,
            UserName = dto.UserName,
        };

    public static void UserUpdate(this User user, UpdateUserDto dto)
    {
        user.FullName = dto.FullName;
        user.UserName = dto.UserName;
    }

    public static UserDto Response(this User user)
        => new UserDto
        {
            Id = user.Id,
            ChatId = user.ChatId,
            FullName = user.FullName,
            UserName = user.UserName,
            UpdatedTime = DateTimeOffset.UtcNow
        };
}
