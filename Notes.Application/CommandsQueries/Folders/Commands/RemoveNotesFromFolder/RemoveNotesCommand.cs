using MediatR;

namespace Notes.Application.CommandsQueries.Folders.Commands.RemoveNotesFromFolder;

public class RemoveNotesCommand: IRequest
{
    public Guid FolderId { get; set; }
}