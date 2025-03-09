using DemoCQRS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    DemoDbContext dbContext
    ) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var duplicateEmail = await dbContext
            .Users
            .AnyAsync(r => r.Id != request.Id && r.Email == request.Email, cancellationToken);

        if (duplicateEmail)
            throw new InvalidDataException($"Email with:{request.Email} already exist.");

        var user = await dbContext
            .Users
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (user is null)
            throw new InvalidDataException($"User with Id:{request.Id} does not exist.");

        user.Name = request.Name;
        user.Email = request.Email;
        user.Phone = request.Phone;
        user.UpdatedAt = DateTimeOffset.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
