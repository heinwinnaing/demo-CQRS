using MediatR;
using System.ComponentModel;

namespace DemoCQRS.Queries.GetUserList;

public class GetUserListQuery
    : IRequest<IEnumerable<GetUserListQueryResponse>>
{
    [DefaultValue(10)]
    public int Size { get; set; } = 10;

    [DefaultValue(1)]
    public int Page { get; set; } = 1;
    public string? Keyword { get; set; }
}
