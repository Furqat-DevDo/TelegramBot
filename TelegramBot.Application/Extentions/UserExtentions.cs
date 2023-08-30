using Microsoft.EntityFrameworkCore.Metadata;
using TelegramBot.Application.Models;
using TelegramBot.Core.Entities;

namespace TelegramBot.Application.Extentions;

public static class UserExtentions
{
    public static GetUserDto GetResponse(this User user)
        => new GetUserDto
        {
            Id = user.Id,
            ChatId = user.ChatId,
            FullName=user.FullName,
            Created=user.Created
        };

    public static User CreateUser(this CreateUserDto user)
        => new User
        {
            ChatId = user.ChatId,
            FullName = user.FullName,
            Created = user.Created
        };

    public static void UpdateUser(this User user, UpdateUserDto updateUser)
    {
        user.ChatId = updateUser.ChatId;
        user.FullName = updateUser.FullName;
        user.Created = updateUser.Created;
    }
}
