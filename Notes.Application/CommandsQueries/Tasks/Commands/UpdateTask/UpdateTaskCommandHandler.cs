using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;

namespace Notes.Application.CommandsQueries.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommand>
{
    private readonly INotesDbContext _dbContext;

    public UpdateTaskCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(UpdateTaskCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Tasks.FirstOrDefaultAsync(task =>
            task.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
            throw new NotFoundException(nameof(Task), request.Id);

        entity.Title = request.Title;
        entity.EditDate = DateTime.Now.ToUniversalTime();
        entity.SubTasks = request.SubTasks;
        entity.Id = request.Id;
        entity.UserId = request.UserId;

        _dbContext.Tasks.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}