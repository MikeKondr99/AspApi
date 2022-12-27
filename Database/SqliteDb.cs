using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Database;

public class SqliteDb : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();

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

        var users = new Faker<User>()
        .RuleFor(u => u.Id,f=> Guid.NewGuid())
        .RuleFor(u => u.Username,f => f.Internet.UserName())
        .RuleFor(u => u.Password,f => f.Internet.Password())
        .RuleFor(u => u.Salt,f => User.GenSalt())
        .RuleFor(u => u.PasswordHash,(f,u) => User.HashString(u.Password,u.Salt))
        .RuleFor(u => u.FirstName, f => f.Name.FirstName().OrNull(f,0.20f))
        .RuleFor(u => u.LastName, f => f.Name.LastName().OrNull(f,0.60f))
        .GenerateBetween(40, 60);

        var projects = new Faker<Project>()
        .RuleFor(p => p.Id,f => Guid.NewGuid())
        .RuleFor(p => p.Name,f => f.Name.JobTitle())
        .RuleFor(p => p.Description,f => f.Hacker.Phrase())
        .RuleFor(p => p.Link,f => f.Internet.Url())
        .RuleFor(p => p.OwnerId,f => f.PickRandom(users).Id)
        .GenerateBetween(25,35);


        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Project>().HasData(projects);
    }
}
