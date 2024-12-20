namespace the_memory_game_asp_dotnet_core.Models.DTOs.Requests;

public class UserRequest
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public class Create
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
    
    public class Get
    {
        public Guid UserId { get; set; }
    }
    
    public class Update
    {
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsPaidUser { get; set; }
    }
    
    public class Delete
    {
        public Guid UserId { get; set; }
    }
}
