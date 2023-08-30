
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TelegramBot.Application.Extentions;
using TelegramBot.Application.Models;
using TelegramBot.Core.Data;
using TelegramBot.Core.Entities;

namespace TelegramBot.Application.Services;

public class StorageService : IStorageService
{
    private readonly AppDbContext _appDbContext;
    public StorageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<GetUserDto> CreateUser(CreateUserDto request)
    {
        var user = request.CreateUser();

        var newUser = await _appDbContext.Users.AddAsync(user);

        return newUser.Entity.GetResponse(); 
    }

    public async Task<bool> DeleteUserById(int id)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id);
        if (user is null)
            throw new Exception();
        
        _appDbContext.Users.Remove(user);

        if (await _appDbContext.SaveChangesAsync()<=0)
            throw new Exception();
        return true;
    }

    public async Task<IEnumerable<GetUserDto>> GetUserAll()
    {
        var users = await _appDbContext.Users.ToListAsync();
       
        return users.Any() ?
            users.Select(u=>u.GetResponse()) :
            new List<GetUserDto>();
    }

    public async Task<GetUserDto> GetUserById(int id)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (user is null)
            throw new Exception();
        
        return user.GetResponse();
    }

    public async Task<GetUserDto> UpdateUser(int id, UpdateUserDto request)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (user is null)
            throw new Exception();
        
        user.UpdateUser(request);
        
        _appDbContext.Users.Update(user);
        
        if (await _appDbContext.SaveChangesAsync() <= 0)
            throw new Exception();
       
        return user.GetResponse() ;
    }
}
