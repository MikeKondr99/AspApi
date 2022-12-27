using System.ComponentModel.DataAnnotations;
using AspApi.Controllers;
using Bogus;

namespace AspApi.Database;

public class Project : IHasKey<Guid>
{
    [Key]
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = "";
    public string? Description { get; set; } = "";
    public string Link { get; set; } = "";
    public virtual Guid OwnerId { get; set; } = Guid.Empty;
    public virtual User Owner { get; set; } = null!;

}

