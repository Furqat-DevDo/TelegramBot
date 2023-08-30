using TelegramBot.Application.Models;

namespace TelegramBot.Application.Services;
public interface IStorageService
{
    public Task<GetUserDto> CreateUser(CreateUserDto request);
    public Task<GetUserDto> GetUserById(int id);
    public Task<IEnumerable<GetUserDto>> GetUserAll();
    public Task<bool> DeleteUserById(int id);
    public Task<GetUserDto> UpdateUser(int id, UpdateUserDto request);
}
