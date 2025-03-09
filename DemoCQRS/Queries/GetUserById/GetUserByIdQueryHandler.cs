using DemoCQRS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.Queries.GetUserById;

public class GetUserByIdQueryHandler(DemoDbContext dbContext)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
{
    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var user = await dbContext
            .Users
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        if (user is null)
            throw new InvalidDataException($"User with Id:{request.Id} does not exist");

        return new GetUserByIdQueryResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone,
            Status = user.Status,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
        };
    }
}
