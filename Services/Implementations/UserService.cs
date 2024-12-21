namespace the_memory_game_asp_dotnet_core.Services.Implementations;

using AutoMapper;

using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Entities;
using Interfaces;
using the_memory_game_asp_dotnet_core.Repositories.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<UserResponse.Create> Create(UserRequest.Create request)
    {
        // Hash the password
        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        // Map the request to a User entity
        var user = _mapper.Map<User>(request);
        
        // Create the user
        user = await _userRepository.Create(user);
        
        // Return the session ID
        return new UserResponse.Create
        {
            UserId = user.UserId,
            Username = user.Username
        };
    }
    
    public async Task<UserResponse.Login> Login(UserRequest.Login request)
    {
        // Find the user by their username
        var user = await _userRepository.GetByUsername(request.Username);
        
        // Add null check here
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }
        
        // Compare it to the stored password
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }
        
        // Return the session ID
        return new UserResponse.Login
        {
            UserId = user.UserId,
            Username = user.Username
        };
    }
    
    public async Task<UserResponse.Get> GetById(UserRequest.Get request)
    {
        // Find the user by their ID
        var user = await _userRepository.GetById(request.UserId);
        
        // Map the user to a response
        return _mapper.Map<UserResponse.Get>(user);
    }
    
    public async Task<UserResponse.Get> Update(UserRequest.Update request)
    {
        // Update user and get the result directly from repository
        var updatedUser = await _userRepository.Update(request);
    
        // Map and return the updated user
        return _mapper.Map<UserResponse.Get>(updatedUser);
    }
    
    public async Task<UserResponse.PurchasePremium> PurchasePremium(UserRequest.PurchasePremium request)
    {
        // Update premium status and get updated user
        var updatedUser = await _userRepository.PurchasePremium(request);
    
        // Map and return the response
        return new UserResponse.PurchasePremium
        {
            UserId = updatedUser.UserId,
            Username = updatedUser.Username,
            IsPaidUser = updatedUser.IsPaidUser
        };
    }
}
