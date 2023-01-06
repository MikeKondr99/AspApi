using FluentValidation;
using AspApi.Dto.Users;
using AspApi.Validators;

namespace AspApi.Validators;

public class UserPatchValidator : AbstractValidator<UserPatchDto>
{
    public UserPatchValidator()
    {
        Include(new NamesValidator());
    }
}

