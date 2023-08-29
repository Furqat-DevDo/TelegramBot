using Microsoft.EntityFrameworkCore;
using TelegramBot.Application.DTOs;
using TelegramBot.Application.Exceptions;
using TelegramBot.Application.Extensions;
using TelegramBot.Application.Services.Interfaces;
using TelegramBot.Core.Data;

namespace TelegramBot.Application.Services;

public class StorageService : IStorageService
{
    private readonly AppDbContext _dbContext;
    public StorageService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<UserDto> CreateUser(CreateUserDto dto)
    {
        var user = await _dbContext.Users.AddAsync(dto.UserCreate());

        return _dbContext.SaveChanges() > 0 ? user.Entity.Response() 
            : throw new InternalServerErrorException("Internal Server Error");
    }

    public async Task<bool> DeleteUser(long id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        return user.IsDeleted = true;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
        => await _dbContext
                .Users
                .Select(u => u.Response())
                .ToListAsync();
   

    public async Task<UserDto> GetUserById(long id)
    {
        var user = await  _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id);
        if(user is null)
        {
            throw new UserNotFoundException("User not found");
        }

        return user.Response();    
    }

    public async Task<UserDto> UpadateUser(UpdateUserDto dto)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (user is null)
        {
            throw new UserNotFoundException("User not found");
        }

        user.UserUpdate(dto);
        _dbContext.Update(user);
        return _dbContext.SaveChanges() > 0 ? user.Response()
            : throw new InternalServerErrorException("Internal Server Error");
    }
}
