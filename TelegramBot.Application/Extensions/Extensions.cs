using TelegramBot.Application.Models.Request;
using TelegramBot.Application.Models.Response;
using TelegramBot.Core.Entity;

namespace TelegramBot.Application.Extensions;

static class Extensions
{
    public static void UpdateUser(this User user, UpdateUser request)
    {
        user.FullName=request.FullName;
        user.PhonNumber=request.PhonNumber;
        user.UserName = request.UserName;
        user.UpdateDate = request.UpdateDate;
    }
    public static User CreateUser(this CreateUser entitie)
        => new User
        {
            PhonNumber = entitie.PhonNumber,
            FullName = entitie.FullName,
            UserName = entitie.UserName,
            ChatId=entitie.ChatId
        };

    public static GetUserResponse ResponseUser(this User entitie)
     => new GetUserResponse
     {
         Id = entitie.Id,
         FullName = entitie.FullName,
         ChatId = entitie.ChatId,
         UserName = entitie.UserName,
         PhonNumber = entitie.PhonNumber,
         CreateDate = entitie.CreateDate,
         UpdateDate = entitie.UpdateDate,
     };



}
