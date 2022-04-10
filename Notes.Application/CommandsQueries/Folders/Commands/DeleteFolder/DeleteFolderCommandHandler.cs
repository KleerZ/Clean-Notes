using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Commands.DeleteFolder;

public class DeleteFolderCommandHandler: IRequestHandler<DeleteFolderCommand>
{
    private readonly INotesDbContext _dbContext;

    public DeleteFolderCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteFolderCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Folders
            .FindAsync(new object[] {request.Id}, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
            throw new NotFoundException(nameof(Folder), request.Id);

        _dbContext.Folders.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}