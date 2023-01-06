using FluentValidation;
using AspApi.Database;

namespace AspApi.Validators;

public class NamesValidator : AbstractValidator<IHaveNames>
{
    public NamesValidator()
    {
        RuleFor(u => u.FirstName)
            .MinimumLength(3)
            .WithName("Имя")
            .When(x => x.FirstName is not null);

        RuleFor(u => u.LastName)
            .MinimumLength(3)
            .WithName("Фамилия")
            .When(x => x.LastName is not null);
    }
}


