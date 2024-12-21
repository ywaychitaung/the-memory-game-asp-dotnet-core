namespace the_memory_game_asp_dotnet_core.Repositories.Implementations;

using Microsoft.EntityFrameworkCore;

using Data.Databases;
using Interfaces;
using Models.Entities;

public class ScoreRepository : IScoreRepository
{
    private readonly ApplicationDbContext _context;
   
    public ScoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
   
    public async Task<Score> Create(Score score)
    {
        // Add the score to the database
        await _context.Scores.AddAsync(score);
       
        // Save the changes
        await _context.SaveChangesAsync();
       
        // Return the score
        return score;
    }

    public async Task<List<Score>> Get()
    {
        // Get all scores ordered by points in descending order (highest first)
        return await _context.Scores
            .OrderByDescending(s => s.Points)
            .ToListAsync();
    }
}
