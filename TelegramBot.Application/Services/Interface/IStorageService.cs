using TelegramBot.Application.Models.Request;
using TelegramBot.Application.Models.Response;

namespace TelegramBot.Application.Services.Interface;

public interface IStorageService
{
    Task<Dto> CreateUser(CreateUserDto dto);
    Task<Dto> UpdateUser(UpdateUserDto dto);
    Task<bool> DeleteUser(long id);
    Task<Dto> GetUser(long id);
    Task<IEnumerable<Dto>> GetAllUsers();
}
