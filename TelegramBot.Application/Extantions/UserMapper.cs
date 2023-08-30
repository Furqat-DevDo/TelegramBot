using Telegram.Bot.Types;
using TelegramBot.Application.Models.Request;
using TelegramBot.Application.Models.Response;
using TelegramBot.Core.Entities;
using User = TelegramBot.Core.Entities.User;

namespace TelegramBot.Application.Extantions
{
    public static class UserMapper
    {
        public static User CreateUser(this CreateUserDto dto)
       => new User
       {
           FullName = dto.FullName,
           ChatId = dto.ChatId,
           NickName = dto.NickName
       };

        public static Dto ResponseUser(this User user)
      => new Dto
      {
          Id = user.Id,
          FullName = user.FullName,
          ChatId = user.ChatId,
          NickName = user.NickName,
          Created = user.Created,
      };

        public static void UpdateUserDto(this User user, UpdateUserDto updateUser)
        {
            user.Id = updateUser.Id;
            user.FullName = updateUser.FullName;
            user.NickName = updateUser.NickName;
            user.ChatId = updateUser.ChatId;
        }
    }
}
