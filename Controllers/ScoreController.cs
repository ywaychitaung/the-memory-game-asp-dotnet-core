namespace the_memory_game_asp_dotnet_core.Controllers;

using Microsoft.AspNetCore.Mvc;

using Models.DTOs.Requests;
using Services.Interfaces;

[ApiController]
[Route("api/scores")]
public class ScoreController : ControllerBase
{
    private readonly IScoreService _scoreService;

    public ScoreController(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ScoreRequest.Create request)
    {
        var response = await _scoreService.Create(request);
        return Ok(response);
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var response = await _scoreService.Get();
        return Ok(response);
    }
}
