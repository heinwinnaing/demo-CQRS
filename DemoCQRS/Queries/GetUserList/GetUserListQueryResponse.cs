using DemoCQRS.Domain.Users;

namespace DemoCQRS.Queries.GetUserList;

public class GetUserListQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public UserStatus? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
