using FluentValidation;
using AspApi.Database;
using AspApi.Validators;

namespace AspApi.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        Include(new KeyValidator<Guid>());
        Include(new LoginValidator());
        Include(new NamesValidator());
    }

}


