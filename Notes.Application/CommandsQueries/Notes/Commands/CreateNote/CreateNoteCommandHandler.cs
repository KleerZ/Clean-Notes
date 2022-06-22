using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler: IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly INotesDbContext _dbContext;
    public CreateNoteCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateNoteCommand request,
        CancellationToken cancellationToken)
    {
        if (request.FolderId == Guid.Empty)
            request.FolderId = null;
        
        var note = new Note
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Text = request.Text,
            EditDate = DateTime.UtcNow,
            FolderId = request.FolderId
        };

        await _dbContext.Notes.AddAsync(note, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}