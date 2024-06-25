using Microsoft.EntityFrameworkCore;
using UserManagement.Domain;

namespace UserManagement.Infrastructure;

public class UserMySQLContext : DbContext
{
    public UserMySQLContext(DbContextOptions<UserMySQLContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Create unique index on User.UserId
        modelBuilder.Entity<User>().HasKey(s => s.UserId);
        modelBuilder.Entity<User>().HasIndex(s => s.UserId).IsUnique();

        modelBuilder.Entity<Support>().HasKey(p => p.SupportId);
        modelBuilder.Entity<Support>().HasOne(p => p.User).WithMany(s => s.Supports).HasForeignKey(p => p.UserId);

        var Logitech = new User
        {
            UserId = 1,
            Email = "Logitech@mail.com",
            FirstName = "John Doe",
            LastName = "123456789",
            PhoneNumber = "Logitech BV.",
            Address = "Logitech address"
        };

        var Pokemon = new User
        {
            UserId = 2,
            Email = "Pokemon@mail.com",
            FirstName = "Ash Ketchum",
            LastName = "987654321",
            PhoneNumber = "Pokemon Inc.",
            Address = "Pokemon address"

        };

        var RedBull = new User
        {
            UserId = 3,
            Email = "Redbull@mail.com",
            FirstName = "Max Verstappen",
            LastName = "123456789",
            PhoneNumber = "Red Bull Racing",
            Address = "Red Bull Racing address"
        };

        modelBuilder.Entity<User>().HasData(
                Logitech, Pokemon, RedBull
            );
    }
}
