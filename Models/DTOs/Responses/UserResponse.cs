namespace the_memory_game_asp_dotnet_core.Models.DTOs.Responses;

public class UserResponse
{
    public class Create
    {
        public Guid UserId { get; set; }
    }
    
    public class Login
    {
        public Guid UserId { get; set; }
    }
}
