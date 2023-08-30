using TelegramBot.Application.Models.Request;
using TelegramBot.Application.Models.Response;

namespace TelegramBot.Application.Services;

internal interface IStorageService
{
    Task<List<GetUserResponse>> GetAllUsersAsync();
    Task<GetUserResponse?> GetUserByIdAsync(int id);
    Task<bool> DeletedUserAsync(int id);
    Task<GetUserResponse> CreateUserAsync(CreateUser create_request);
    Task<GetUserResponse> UpdateUserAsync(int id, UpdateUser update_request);

}
