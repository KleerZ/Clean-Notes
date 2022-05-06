using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Commands.RemoveNotesFromFolder;

public class RemoveNotesCommandHandler: IRequestHandler<RemoveNotesCommand>
{
    private readonly INotesDbContext _dbContext;

    public RemoveNotesCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(RemoveNotesCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Folders
            .FirstOrDefaultAsync(n => n.Id == request.FolderId, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException(nameof(Folder), request.FolderId);

        var notesInFolder = await _dbContext.Notes
            .Where(n => n.FolderId == entity.Id)
            .ToListAsync(cancellationToken: cancellationToken);

        foreach (var note in notesInFolder)
            note.FolderId = null;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}