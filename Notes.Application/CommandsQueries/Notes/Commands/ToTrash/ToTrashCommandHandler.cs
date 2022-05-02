using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Notes.Commands.ToTrash;

public class ToTrashCommandHandler: IRequestHandler<ToTrashCommand>
{
    private readonly INotesDbContext _dbContext;
    public ToTrashCommandHandler(INotesDbContext context) =>
        _dbContext = context;

    public async Task<Unit> Handle(ToTrashCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes
            .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(Note), request.Id);

        entity.isDeleted = true;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}