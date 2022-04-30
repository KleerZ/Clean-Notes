using MediatR;

namespace Notes.Application.CommandsQueries.Notes.Commands.UpdateNote;

public class UpdateNoteCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public bool isDeleted { get; set; }
    public Guid FolderId { get; set; }
}