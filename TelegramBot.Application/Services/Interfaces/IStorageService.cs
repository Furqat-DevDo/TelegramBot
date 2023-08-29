using TelegramBot.Application.DTOs;

namespace TelegramBot.Application.Services.Interfaces;

public interface IStorageService
{
    public Task<UserDto> CreateUser(CreateUserDto dto);
    public Task<IEnumerable<UserDto>> GetAllUsers();
    public Task<UserDto> GetUserById(long id);
    public Task<UserDto> UpadateUser(UpdateUserDto dto);
    public Task<bool> DeleteUser(long id);
}
