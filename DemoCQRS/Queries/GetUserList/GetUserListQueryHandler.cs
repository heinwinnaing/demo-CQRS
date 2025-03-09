using DemoCQRS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.Queries.GetUserList;

public class GetUserListQueryHandler(
    DemoDbContext dbContext
    ): IRequestHandler<GetUserListQuery, IEnumerable<GetUserListQueryResponse>>
{

    async Task<IEnumerable<GetUserListQueryResponse>> IRequestHandler<GetUserListQuery, IEnumerable<GetUserListQueryResponse>>.Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Users.AsQueryable();

        if(!string.IsNullOrEmpty(request.Keyword)) 
            query = query.Where(r => r.Name.Contains(request.Keyword) 
                || r.Email.Contains(request.Keyword)
                || r.Phone.Contains(request.Keyword));

        var users = await query
            .Skip((request.Page - 1) * request.Size)
            .Take(request.Size)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users.Select(s => new GetUserListQueryResponse 
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            Phone = s.Phone,
            Status = s.Status,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
        });
    }
}
