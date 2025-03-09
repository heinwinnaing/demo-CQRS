using FluentValidation;

namespace DemoCQRS.Commands.CreateUser;

public class CreateUserCommandValidator
    : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();
    }
}
