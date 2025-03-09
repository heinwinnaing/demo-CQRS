using DemoCQRS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.Commands.DeleteUser;

public class DeleteUserByIdCommandHandler(
    DemoDbContext dbContext
    ) : IRequestHandler<DeleteUserByIdCommand>
{
    public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext
            .Users
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        if (user is null)
            throw new InvalidDataException($"User with Id:{request.Id} does not exist.");

        await dbContext
            .Users
            .Where(r => r.Id == user.Id)
            .ExecuteDeleteAsync(cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
