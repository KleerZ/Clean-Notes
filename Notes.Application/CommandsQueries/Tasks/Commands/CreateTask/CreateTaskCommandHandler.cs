using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
    
namespace Notes.Application.Tasks.Commands.CreateTask;

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
            EditDate = request.EditDate
        };

        await _dbContext.Tasks.AddAsync(task, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}