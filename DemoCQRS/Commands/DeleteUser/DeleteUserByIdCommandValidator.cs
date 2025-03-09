using FluentValidation;

namespace DemoCQRS.Commands.DeleteUser;

public class DeleteUserByIdCommandValidator
    : AbstractValidator<DeleteUserByIdCommand>
{
    public DeleteUserByIdCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .NotEmpty();
    }
}
