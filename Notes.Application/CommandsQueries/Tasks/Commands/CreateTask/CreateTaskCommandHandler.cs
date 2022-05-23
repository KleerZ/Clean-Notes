using MediatR;
using Notes.Application.Interfaces;

namespace Notes.Application.CommandsQueries.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly INotesDbContext _dbContext;

    public CreateTaskCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateTaskCommand request,
        CancellationToken cancellationToken)
    {
        var task = new Domain.Tasks()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            EditDate = DateTime.Now.ToUniversalTime().AddHours(3)
        };

        await _dbContext.Tasks.AddAsync(task, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}