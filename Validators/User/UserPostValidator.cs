using FluentValidation;
using AspApi.Dto.Users;
using System.Text.RegularExpressions;

namespace AspApi.Validators;

public class UserPostValidator : AbstractValidator<UserPostDto>
{
    static Regex passwordRgx = new Regex("^[a-zA-Z0-9]*$",RegexOptions.Compiled);
    public UserPostValidator()
    {
        RuleFor(u => u.Username)
            .MinimumLength(8)
            .WithName("Логин");

        RuleFor(u => u.Password)
            .MinimumLength(8)
            .Matches(passwordRgx)
            .WithName("Пароль");

        RuleFor(u => u.FirstName)
            .MinimumLength(3)
            .When(x => x.FirstName is not null)
            .WithName("Имя");

        RuleFor(u => u.LastName)
            .MinimumLength(3)
            .When(x => x.FirstName is not null)
            .WithName("Фамилия");
    }
}

