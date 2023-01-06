using FluentValidation;
using AspApi.Controllers;

namespace AspApi.Validators;

public class KeyValidator<T> : AbstractValidator<IHasKey<T>>
{
    public KeyValidator()
    {
        RuleFor(u=> u.Id)
            .NotNull();
    }
}


