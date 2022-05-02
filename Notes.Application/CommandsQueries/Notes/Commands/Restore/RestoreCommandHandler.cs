using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Notes.Commands.Restore;

public class RestoreCommandHandler: IRequestHandler<RestoreCommand>
{
    private readonly INotesDbContext _context;

    public RestoreCommandHandler(INotesDbContext context) =>
        _context = context;

    public async Task<Unit> Handle(RestoreCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(Note), request.Id);

        entity.isDeleted = false;
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}