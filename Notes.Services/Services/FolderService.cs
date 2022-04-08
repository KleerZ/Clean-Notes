using MediatR;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Domain;

namespace Notes.Services.Services;

public class FolderService
{
    private readonly IMediator _mediator;

    public FolderService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<FolderListVm> GetList(Guid UserId)
    {
        var query = new GetFolderListQuery
        {
            UserId = UserId
        };

        var folderList = await _mediator.Send(query);

        return folderList;
    }
}