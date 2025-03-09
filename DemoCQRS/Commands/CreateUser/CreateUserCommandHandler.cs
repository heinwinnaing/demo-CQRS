using DemoCQRS.Domain.Users;
using DemoCQRS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.Commands.CreateUser;

public class CreateUserCommandHandler(
    DemoDbContext dbContext)
    : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
    public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, 
        CancellationToken cancellationToken)
    {
        var duplicateEmail = await dbContext
            .Users
            .AnyAsync(r => r.Email == request.Email, cancellationToken);

        if (duplicateEmail)
            throw new InvalidDataException($"Email with:{request.Email} already exist.");

        var user = new User(request.Name, request.Email, request.Phone);

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateUserCommandResponse { Id = user.Id };
    }
}
