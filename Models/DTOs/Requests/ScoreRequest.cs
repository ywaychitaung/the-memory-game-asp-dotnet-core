using Microsoft.AspNetCore.Mvc;

namespace the_memory_game_asp_dotnet_core.Models.DTOs.Requests;

public class ScoreRequest
{
    public class Create
    {
        public Guid UserId { get; set; }
        public int TotalMoves { get; set; }
        public int TotalSeconds { get; set; }
    }
}
