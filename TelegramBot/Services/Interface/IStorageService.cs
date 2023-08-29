using System.Collections;
using TelegramBot.Models.Request;
using TelegramBot.Models.Response;

namespace TelegramBot.Services.Interface;

public interface IStorageService
{
    Task<Dto> CreateUser(CreateUserDto dto);
    Task<Dto> UpdateUser(UpdateUserDto dto);
    Task<bool> DeleteUser(long id);
    Task<Dto> GetUser(long id);
    Task<IEnumerable<Dto>> GetAllUsers();
}
