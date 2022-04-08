using MediatR;

namespace Notes.Application.CommandsQueries.Notes.Commands.CreateNote;

public class CreateNoteCommand: IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Guid? FolderId { get; set; }
}