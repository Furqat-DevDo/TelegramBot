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

        return await _dbContext.SaveChangesAsync() > 0 ? user.Entity.Response() 
            : throw new InternalServerErrorException("Internal Server Error");
    }

    public async Task<bool> DeleteUser(long id)
    {
        var user = await _dbContext.Users
        .FirstOrDefaultAsync(x => x.Id == id) ??
        throw new UserNotFoundException("User with the given id does not exist !!");

        user.IsDeleted = true;

       return await _dbContext.SaveChangesAsync () > 0;

    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
        => await _dbContext
                .Users
                .AsNoTracking()
                .Select(u => u.Response())
                .ToListAsync();
   

    public async Task<UserDto> GetUserById(long id)
    {
        var user = await  _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id)
             ?? throw new UserNotFoundException("User not found");
    
        return user.Response();    
    }

    public async Task<UserDto> UpadateUser(UpdateUserDto dto)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == dto.Id)??       
                throw new UserNotFoundException("User not found");
        
        user.UserUpdate(dto);
        
        return await  _dbContext.SaveChangesAsync() > 0 ? user.Response()
            : throw new InternalServerErrorException("Internal Server Error");
    }
}
