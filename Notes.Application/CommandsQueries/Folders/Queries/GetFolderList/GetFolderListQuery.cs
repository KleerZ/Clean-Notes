using MediatR;

namespace Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;

public class GetFolderListQuery: IRequest<FolderListVm>
{
    public Guid UserId { get; set; }
}