using FluentValidation;
using AspApi.Database;
using AspApi.Dto.Users;
namespace AspApi.Validators;


public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u=> u.Id)
            .NotNull();
        RuleFor(u=> u.Username)
            .NotNull()
            .Length(8,30);
        RuleFor(u=> u.Password);
        RuleFor(u=> u.FirstName);
        RuleFor(u=> u.LastName);
    }
}

public class UserPostValidator : AbstractValidator<UserPostDto>
{
    public UserPostValidator()
    {
        RuleFor(u => u.Username)
            .NotNull()
            .Length(8,30);
        RuleFor(u => u.Password);
        RuleFor(u => u.FirstName);
        RuleFor(u => u.LastName);


    }
}

public class UserPatchValidator : AbstractValidator<UserPatchDto>
{
    public UserPatchValidator()
    {
        RuleFor(u => u.FirstName);
        RuleFor(u => u.LastName);
    }
}
