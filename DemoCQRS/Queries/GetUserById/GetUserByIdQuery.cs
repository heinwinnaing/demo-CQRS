using MediatR;

namespace DemoCQRS.Queries.GetUserById;

public class GetUserByIdQuery
    : IRequest<GetUserByIdQueryResponse>
{
    public Guid Id { get; set; }
}
