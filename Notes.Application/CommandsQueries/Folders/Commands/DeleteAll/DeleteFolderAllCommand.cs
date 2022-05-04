using MediatR;

namespace Notes.Application.CommandsQueries.Folders.Commands.DeleteAll;

public class DeleteFolderAllCommand: IRequest
{
    public Guid Id { get; set; }
}