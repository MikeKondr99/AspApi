using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Database;

public class SqliteDb : DbContext
{
    public DbSet<User> Users => Set<User>();

    public SqliteDb() {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        this.Database.EnsureCreated();
    }

    public SqliteDb(DbContextOptions<SqliteDb> options) : base(options) 
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var fake = new Faker<User>()
        .StrictMode(true)
        .RuleFor(u => u.Id,f=> Guid.NewGuid())
        .RuleFor(u => u.Username,f => f.Internet.UserName())
        .RuleFor(u => u.Password,f => f.Internet.Password())
        .RuleFor(u => u.Salt,f => User.GenSalt())
        .RuleFor(u => u.PasswordHash,(f,u) => User.HashString(u.Password,u.Salt))
        .RuleFor(u => u.FirstName, f => f.Name.FirstName())
        .RuleFor(u => u.LastName, f => f.Name.LastName());

        modelBuilder.Entity<User>().HasData(fake.GenerateBetween(40,60));
    }
}
