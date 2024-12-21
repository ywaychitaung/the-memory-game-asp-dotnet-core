namespace the_memory_game_asp_dotnet_core.Controllers;

using Microsoft.AspNetCore.Mvc;

using Models.DTOs.Requests;
using Services.Interfaces;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{UserId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] UserRequest.Get request)
    {
        // Get the user by their ID
        var response = await _userService.GetById(request);
        
        return Ok(response);
    }
    
    [HttpPost("{UserId:guid}/premium")]
    public async Task<IActionResult> PurchasePremium([FromRoute] UserRequest.PurchasePremium request)
    {
        // Update the user's premium status
        var response = await _userService.PurchasePremium(request);
        
        return Ok(response);
    }
}
