using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;

namespace Notes.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly INotesDbContext _dbContext;

    public DeleteTaskCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Tasks
            .FindAsync(new object[] {request.Id}, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
            throw new NotFoundException(nameof(Tasks), request.Id);

        _dbContext.Tasks.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}