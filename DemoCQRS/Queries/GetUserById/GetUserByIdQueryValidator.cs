using FluentValidation;

namespace DemoCQRS.Queries.GetUserById;

public class GetUserByIdQueryValidator
    : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(r => r.Id)
            .NotNull()
            .NotEmpty();
    }
}
