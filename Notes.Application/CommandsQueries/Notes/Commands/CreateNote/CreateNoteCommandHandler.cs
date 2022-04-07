using MediatR;
using Notes.Application.CommandsQueries.Notes.Commands.CreateNote;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler: IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly INotesDbContext _dbContext;
    public CreateNoteCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateNoteCommand request,
        CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserId,
            Title = request.Title,
            Text = request.Text,
            Id = Guid.NewGuid(),
            EditDate = DateTime.Now
        };

        await _dbContext.Notes.AddAsync(note, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}