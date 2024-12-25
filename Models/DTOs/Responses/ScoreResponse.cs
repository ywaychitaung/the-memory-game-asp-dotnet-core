namespace the_memory_game_asp_dotnet_core.Models.DTOs.Responses;

public class ScoreResponse
{
    public class Create
    {
        public Guid ScoreId { get; set; }
        public int TotalMoves { get; set; }
        public int TotalSeconds { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
    public class Get
    {
        public string Username { get; set; }
        public int TotalMoves { get; set; }
        public int TotalSeconds { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
