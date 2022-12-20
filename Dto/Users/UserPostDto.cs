using AspApi.Database;

namespace AspApi.Dto.Users;


public class UserPostDto : IPostDto<User>
{
    public string Username { get; set; } = "";

    public string Password { get; set; } = ""; // for debug

    public string? FirstName { get; set; } = "";

    public string? LastName { get; set; } = "";

    public User Create()
    {
        var salt = User.GenSalt();
        var hash = User.HashString(this.Password,salt);
        return new User
        {
            Id  = Guid.NewGuid(),
            Username  = this.Username,
            Password  = this.Password, // for debug
            PasswordHash  = hash,
            Salt  = salt,
            FirstName  = this.FirstName,
            LastName  = this.LastName,
        };
    }
}
