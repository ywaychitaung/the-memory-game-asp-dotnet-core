namespace the_memory_game_asp_dotnet_core.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? FullName { get; set; }

    public bool IsPaidUser { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public User() { }
    
    public User(string username, string password, string fullName)
    {
        UserId = Guid.NewGuid();
        Username = username;
        Password = password;
        FullName = fullName;
        IsPaidUser = false;
        CreatedAt = DateTime.Now;
    }
}
