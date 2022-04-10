using MediatR;
using Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;
using Notes.Application.CommandsQueries.Folders.Commands.DeleteFolder;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.MVC.Models;

namespace Notes.MVC.Services;

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

    public async Task Delete(Guid id, Guid UserId)
    {
        var query = new DeleteFolderCommand
        {
            Id = id,
            UserId = UserId
        };

        await _mediator.Send(query);
    }

    public async Task Add(string name, Guid UserId)
    {
        var query = new CreateFolderCommand()
        {
            UserId = UserId,
            Name = name
        };

        await _mediator.Send(query);
    }
}