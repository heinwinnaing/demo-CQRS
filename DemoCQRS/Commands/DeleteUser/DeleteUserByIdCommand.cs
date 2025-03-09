using MediatR;

namespace DemoCQRS.Commands.DeleteUser;

public class DeleteUserByIdCommand
    : IRequest
{
    public Guid Id { get; set; }
}
