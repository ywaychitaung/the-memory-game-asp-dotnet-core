namespace the_memory_game_asp_dotnet_core.Repositories.Implementations;

using Microsoft.EntityFrameworkCore;

using Data.Databases;
using Interfaces;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Entities;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> Create(User user)
    {
        // Add the user to the database
        await _context.Users.AddAsync(user);
        
        // Save the changes
        await _context.SaveChangesAsync();
        
        // Return the user
        return user;
    }

    public Task<User> Delete(UserRequest.Delete request)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetById(Guid userid)
    {
        // Find the user by their ID
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == userid);
        
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {userid} not found");
        }
    
        return user;
    }
    
    public async Task<User> GetByUsername(string username)
    {
        // Find the user by their username
        var user = await _context.Users
            .FirstOrDefaultAsync(u => EF.Functions.Collate(u.Username, "utf8mb4_bin") == username);
        
        if (user == null)
        {
            throw new KeyNotFoundException($"User with username {username} not found");
        }
    
        return user;
    }

    public async Task<User> Update(UserRequest.Update request)
    {
        // Find the user by their ID
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == request.UserId);
    
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {request.UserId} not found");
        }
    
        // Update the user properties
        user.IsPaidUser = request.IsPaidUser;
    
        // Mark the entity as modified
        _context.Users.Update(user);
    
        // Save the changes
        await _context.SaveChangesAsync();
    
        // Return the updated user
        return user;
    }
    
    public async Task<User> PurchasePremium(UserRequest.PurchasePremium request)
    {
        // Find the user by their ID
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == request.UserId);
    
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {request.UserId} not found");
        }
    
        // Update the user properties
        user.IsPaidUser = true;
    
        // Mark the entity as modified
        _context.Users.Update(user);
    
        // Save the changes
        await _context.SaveChangesAsync();
    
        // Return the updated user
        return user;   
    }
}
