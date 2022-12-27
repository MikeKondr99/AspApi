using FluentValidation;
using AspApi.Dto.Users;

namespace AspApi.Validators;

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

