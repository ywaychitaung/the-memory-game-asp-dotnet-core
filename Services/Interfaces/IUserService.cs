namespace the_memory_game_asp_dotnet_core.Services.Interfaces;

using Models.DTOs.Requests;
using Models.DTOs.Responses;

public interface IUserService
{
    public Task<UserResponse.Create> Create(UserRequest.Create request);
    public Task<UserResponse.Login> Login(UserRequest.Login request);
    public Task<UserResponse.Get> GetById(UserRequest.Get request);
}
