using FluentValidation;
using AspApi.Database;
using AspApi.Dto.Users;
using System.Text.RegularExpressions;

namespace AspApi.Validators;


public class UserValidator : AbstractValidator<User>
{
    static Regex passwordRgx = new Regex("^[a-zA-Z0-9]*$",RegexOptions.Compiled);
    public UserValidator()
    {

        RuleFor(u=> u.Id)
            .NotNull();

        RuleFor(u => u.Username)
            .NotNull()
            .MinimumLength(8);

        RuleFor(u => u.Password)
            .NotNull()
            .MinimumLength(8)
            .Matches(passwordRgx);

        RuleFor(u => u.FirstName)
            .MinimumLength(3)
            .WithMessage("Имя должно быть больше 3ех символов")
            .When(x => x.FirstName is not null);

        RuleFor(u => u.LastName)
            .MinimumLength(3)
            .WithMessage("Фамилия должно быть больше 3ех символов")
            .When(x => x.FirstName is not null);
    }
}

public class UserPostValidator : AbstractValidator<UserPostDto>
{
    static Regex passwordRgx = new Regex("^[a-zA-Z0-9]*$",RegexOptions.Compiled);
    public UserPostValidator()
    {
        RuleFor(u => u.Username)
            .NotNull()
            .MinimumLength(8);

        RuleFor(u => u.Password)
            .NotNull()
            .MinimumLength(8)
            .Matches(passwordRgx);

        RuleFor(u => u.FirstName)
            .MinimumLength(3)
            .WithMessage("Имя должно быть больше 3ех символов")
            .When(x => x.FirstName is not null);

        RuleFor(u => u.LastName)
            .MinimumLength(3)
            .WithMessage("Фамилия должно быть больше 3ех символов")
            .When(x => x.FirstName is not null);
    }
}

public class UserPatchValidator : AbstractValidator<UserPatchDto>
{
    public UserPatchValidator()
    {
        RuleFor(u => u.FirstName)
            .MinimumLength(3)
            .WithMessage("Имя должно быть больше 3ех символов")
            .When(x => x.FirstName is not null);

        RuleFor(u => u.LastName)
            .MinimumLength(3)
            .WithMessage("Фамилия должно быть больше 3ех символов")
            .When(x => x.FirstName is not null);
    }
}

