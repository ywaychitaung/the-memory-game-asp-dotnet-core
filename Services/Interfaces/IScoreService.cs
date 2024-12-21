namespace the_memory_game_asp_dotnet_core.Services.Interfaces;

using Models.DTOs.Requests;
using Models.DTOs.Responses;

public interface IScoreService
{
    public Task<ScoreResponse.Create> Create(ScoreRequest.Create request);
    public Task<List<ScoreResponse.Get>> Get();
}
