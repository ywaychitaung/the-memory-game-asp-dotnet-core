namespace the_memory_game_asp_dotnet_core.Data.Databases;

using Microsoft.EntityFrameworkCore;

using Models.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Score> Scores { get; set; }
}
