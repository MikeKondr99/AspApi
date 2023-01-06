using FluentValidation;
using AspApi.Database;
using System.Text.RegularExpressions;

namespace AspApi.Validators;

public class LoginValidator : AbstractValidator<IHaveLogin>
{
    static Regex passwordRgx = new Regex("^[a-zA-Z0-9]*$",RegexOptions.Compiled);
    public LoginValidator()
    {
        RuleFor(u => u.Username)
            .MinimumLength(8)
            .WithName("Логин");

        RuleFor(u => u.Password)
            .MinimumLength(8)
            .Matches(passwordRgx)
            .WithName("Пароль");
    }
}


