using AspApi.Database;
using Microsoft.AspNetCore.OData.Deltas;

namespace AspApi.Dto.Users;

public class UserPatchDto : PatchDto<User>, IHaveNames
{
    public string? FirstName { get; set; } = null;
    public string? LastName { get; set; } = null;

}

