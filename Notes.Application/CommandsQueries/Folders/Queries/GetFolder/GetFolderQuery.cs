using MediatR;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Queries.GetFolder;

public class GetFolderQuery: IRequest<FolderVM>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}