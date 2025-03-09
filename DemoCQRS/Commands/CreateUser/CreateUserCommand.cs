using MediatR;

namespace DemoCQRS.Commands.CreateUser;

public class CreateUserCommand
    : IRequest<CreateUserCommandResponse>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
}
