using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TelegramBot.Application.Extensions;
using TelegramBot.Application.Models.Request;
using TelegramBot.Application.Models.Response;
using TelegramBot.Application.Services.Exseptions;
using TelegramBot.Core.Data;


namespace TelegramBot.Application.Services.StorageService;

internal class StorageService : IStorageService
{
    private readonly AppDbContext _appDbContext;
    private ILogger<StorageService> _logger;
    public StorageService(AppDbContext appDbContext,
        ILogger<StorageService> logger)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }
    public async Task<GetUserResponse> CreateUserAsync(CreateUser create_request)
    {
        var user = create_request.CreateUser();

        var newuser = await _appDbContext.Users.AddAsync(user);

        if (await _appDbContext.SaveChangesAsync() <= 0)
        {
            _logger.LogError("Unable to save user changes.");
            throw new UnableToSaveUserChangesException();
        }

        return newuser.Entity.ResponseUser();
    }

    public async Task<bool> DeletedUserAsync(int id)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new UserNotFoundException();

        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetUserResponse>> GetAllUsersAsync()
    {
        if (_appDbContext.Users is null)
        {
            _logger.LogError("AppDbContext.Users is null.");
            throw new ArgumentNullException(nameof(_appDbContext.Users));
        }

        return await _appDbContext.Users.Select(p => p.ResponseUser()).ToListAsync();
    }

    public async Task<GetUserResponse?> GetUserByIdAsync(int id)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(p => p.Id == id)
                    ?? throw new UserNotFoundException();

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserAsync(int id, UpdateUser update_request)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id)
            ?? throw new UserNotFoundException();
        user.UpdateUser(update_request);

        if (await _appDbContext.SaveChangesAsync() <= 0)
        {
            _logger.LogError("Unable to save cuser changes.");
            throw new UnableToSaveUserChangesException();
        }

        return user.ResponseUser();

    }
}
