using MediatR;

namespace DemoCQRS.Commands.UpdateUser;

public class UpdateUserCommand
    : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
