namespace the_memory_game_asp_dotnet_core.Repositories.Interfaces;

using Models.Entities;

public interface IScoreRepository
{
    public Task<Score> Create(Score score);
    public Task<List<Score>> Get();
}
