using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Domain;

namespace Notes.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Guid>
{
    private readonly INotesDbContext _dbContext;

    public CreateUserCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}