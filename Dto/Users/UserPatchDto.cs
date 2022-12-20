using AspApi.Database;

namespace AspApi.Dto.Users;

public class UserPatchDto : IPatchDto<User>
{
    public string? FirstName { get; set; } = "";

    public string? LastName { get; set; } = "";

    public User Patch(User user)
    {
        user.FirstName = FirstName ?? user.FirstName;
        user.LastName = LastName ?? user.LastName;
        return user;
    }
}
