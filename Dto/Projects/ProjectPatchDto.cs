using AspApi.Database;
using AspApi.Dto;

namespace AspApi.Dto.Projects;

public class ProjectPatchDto : PatchDto<Project>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

}

