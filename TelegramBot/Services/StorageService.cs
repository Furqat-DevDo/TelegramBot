using Microsoft.EntityFrameworkCore;
using System.Collections;
using Telegram.Bot.Requests.Abstractions;
using TelegramBot.Core.Data;
using TelegramBot.Extantions;
using TelegramBot.Models.Request;
using TelegramBot.Models.Response;
using TelegramBot.Services.Interface;

namespace TelegramBot.Services;

public class StorageService : IStorageService
{
    private readonly AppDbContext _dbContext;
    public StorageService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Dto> CreateUser(CreateUserDto dto)
    {
        if(await _dbContext.Users
            .AnyAsync(b => b.FullName == dto.FullName && b.ChatId == dto.ChatId))
        {
            throw new Exception("User already exist!");
        }

        var user = dto.CreateUser();

        var newUser = _dbContext.Users.Add(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new Exception("Unable To create user!");

        return newUser.Entity.ResponseUser();
    }

    public async Task<IEnumerable<Dto>> GetAllUsers()
        => await _dbContext.Users
        .Select(u=>u.ResponseUser())
        .ToListAsync();


    public async Task<Dto> GetUser(long id)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) 
            throw new Exception("User does not exist!");

        return user.ResponseUser();
    }

    public async Task<Dto> UpdateUser(UpdateUserDto dto)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(d => d.Id == dto.Id);

        if (user == null) 
            throw new Exception("User does not exist!");

        user.UpdateUserDto(dto);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new Exception("Unable To update user!");

        return user.ResponseUser();
    }

    public async Task<bool> DeleteUser(long id)
    {
        var deletedUser = await _dbContext.Users
            .FirstOrDefaultAsync(g => g.Id == id);

        if (deletedUser == null) throw new Exception("Not Fount");

        deletedUser.IsDeleted = true;

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new Exception("Unable to delete this user!");

        return true;
    }
}
