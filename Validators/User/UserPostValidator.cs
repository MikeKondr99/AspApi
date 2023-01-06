using FluentValidation;
using AspApi.Dto.Users;
using System.Text.RegularExpressions;

namespace AspApi.Validators;

public class UserPostValidator : AbstractValidator<UserPostDto>
{
    static Regex passwordRgx = new Regex("^[a-zA-Z0-9]*$",RegexOptions.Compiled);
    public UserPostValidator()
    {
        Include(new LoginValidator());
        Include(new NamesValidator());
    }
}

