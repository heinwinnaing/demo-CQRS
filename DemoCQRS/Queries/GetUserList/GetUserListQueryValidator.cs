using FluentValidation;

namespace DemoCQRS.Queries.GetUserList;

public class GetUserListQueryValidator
    : AbstractValidator<GetUserListQuery>
{
    public GetUserListQueryValidator()
    {
        RuleFor(r => r.Size).InclusiveBetween(10, 100);
        RuleFor(r => r.Size).InclusiveBetween(1, int.MaxValue);
        RuleFor(r => r.Keyword).MaximumLength(100);
    }
}
