using MediatR;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;

public class CreateFolderCommand: IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
}