using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;
using Notes.Application.CommandsQueries.Folders.Commands.DeleteAll;
using Notes.Application.CommandsQueries.Folders.Commands.DeleteFolder;
using Notes.Application.CommandsQueries.Folders.Commands.RemoveNotesFromFolder;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolder;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Domain;
using Notes.MVC.Models;
using Notes.Persistence;

namespace Notes.MVC.Services;

public class FolderService
{
    private readonly IMediator _mediator;
    private readonly NoteDbContext _dbContext;

    public FolderService(IMediator mediator, NoteDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    public async Task<FolderVM> Get(Guid id, Guid UserId)
    {
        var query = new GetFolderQuery
        {
            Id = id,
            UserId = UserId
        };

        var folder = await _mediator.Send(query);

        return folder;
    } 

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

    public async Task<FolderListVm> Rename(CombineNoteFolderViewModel vm, Guid UserId)
    {
        var folder = await _dbContext.Folders
            .FirstOrDefaultAsync(n => n.Id == vm.Folder.Id);

        folder.Name = vm.Folder.Name;
        
        await _dbContext.SaveChangesAsync();

        var folderList = await GetList(UserId);

        return folderList;
    }

    public async Task DeleteAll(Guid id, Guid userId)
    {
        var query = new DeleteFolderCommand
        {
            Id = id,
            UserId = userId
        };

        await _mediator.Send(query);
        
        if (_dbContext.Folders.FirstOrDefault(i => i.Id == id) != null)
            throw new Exception();
    }
    
    public async Task RemoveNotesFromFolder(Guid id)
    {
        var query = new RemoveNotesCommand
        {
            FolderId = id
        };

        await _mediator.Send(query);
    }
}