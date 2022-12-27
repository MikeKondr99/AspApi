using AspApi.Database;
using AspApi.Dto;

namespace AspApi.Dto.Projects;

public class ProjectPostDto : PostDto<Project>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Link { get; set; } = null!;
    public User Owner { get; set; } = null!;
}

