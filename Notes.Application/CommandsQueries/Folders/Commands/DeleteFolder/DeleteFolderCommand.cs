using MediatR;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Commands.DeleteFolder;

public class DeleteFolderCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}