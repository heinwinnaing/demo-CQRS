using FluentValidation;

namespace DemoCQRS.Commands.UpdateUser;

public class UpdateUserCommandValidator
    : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(r => r.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(r => r.Phone)
            .MaximumLength(100);
    }
}
