namespace the_memory_game_asp_dotnet_core.Models.DTOs.Responses;

public class UserResponse
{
    public class Create
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsPaidUser { get; set; }
    }
    
    public class Login
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsPaidUser { get; set; }
    }
    
    public class Get
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsPaidUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
    
    public class PurchasePremium
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsPaidUser { get; set; }
    }
}
