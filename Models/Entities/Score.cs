namespace the_memory_game_asp_dotnet_core.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class Score
{
    [Key]
    public Guid ScoreId { get; set; }
    
    public Guid UserId { get; set; }
    
    public int TotalMoves { get; set; }
    public int TotalSeconds { get; set; }
    
    // Calculated points based on moves and time
    public int Points { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    // Navigation property
    public User User { get; set; }
    
    public Score() { }
    
    public Score(Guid userId, int totalMoves, int totalSeconds, int points)
    {
        ScoreId = Guid.NewGuid();
        UserId = userId;
        TotalMoves = totalMoves;
        TotalSeconds = totalSeconds;
        Points = points;
        CreatedAt = DateTime.Now;
    }
}
