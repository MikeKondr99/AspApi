using AspApi.Database;

namespace AspApi.Dto.Users;


public class UserPostDto : PostDto<User>
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = ""; // for debug
    public string? FirstName { get; set; } = null;
    public string? LastName { get; set; } = null;

    public override User Create()
    {
        var user = base.Create();
        //
        var salt = User.GenSalt();
        var hash = User.HashString(this.Password,salt);
        user.Salt = User.GenSalt();
        user.PasswordHash = User.HashString(user.Password,user.Salt);
        return user;
    }
}
