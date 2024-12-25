namespace the_memory_game_asp_dotnet_core.Services.Implementations;

using AutoMapper;
using Interfaces;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Entities;
using the_memory_game_asp_dotnet_core.Repositories.Interfaces;

public class ScoreService : IScoreService
{
    private readonly IScoreRepository _scoreRepository;
    private readonly IMapper _mapper;
    
    public ScoreService(IScoreRepository scoreRepository, IMapper mapper)
    {
        _scoreRepository = scoreRepository;
        _mapper = mapper;
    }
    
    public async Task<ScoreResponse.Create> Create(ScoreRequest.Create request)
    {
        // Map the request to a Score entity
        var score = _mapper.Map<Score>(request);
        
        // Create the score
        score = await _scoreRepository.Create(score);
        
        // Return the score ID
        return new ScoreResponse.Create
        {
            ScoreId = score.ScoreId,
            TotalSeconds = score.TotalSeconds,
            TotalMoves = score.TotalMoves,
            CreatedAt = score.CreatedAt
        };
    }
    
    public async Task<List<ScoreResponse.Get>> Get()
    {
        // Find the score by its ID
        var score = await _scoreRepository.Get();
        
        // Map the score to a response
        return _mapper.Map<List<ScoreResponse.Get>>(score);
    }
}
