using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolder;
using Notes.Application.CommandsQueries.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.MVC.Models;

namespace Notes.MVC.Services;

public class NoteService
{
    private readonly IMediator _mediator;
    private readonly FolderService _folderService;

    public NoteService(IMediator mediator, FolderService folderService)
    {
        _mediator = mediator;
        _folderService = folderService;
    }

    public async Task<NoteVM> Get(Guid id, Guid userId)
    {
        var query = new GetNoteQuery
        {
            Id = id,
            UserId = userId
        };

        var note = await _mediator.Send(query);
        
        return note;
    }

    public async Task Delete(Guid id, Guid UserId)
    {
        var query = new DeleteNoteCommand
        {
            Id = id,
            UserId = UserId
        };

        await _mediator.Send(query);
    }
    
    public async Task Update(CombineNoteVmFolderListVm vm, Guid UserId)
    {
        var command = new UpdateNoteCommand()
        {
            Id = vm.NoteVm.Id,
            Title = vm.NoteVm.Title,
            Text = vm.NoteVm.Text,
            UserId = UserId,
            FolderId = vm.NoteVm.Folder!.Value
        };

        await _mediator.Send(command);
    }

    public async Task<List<NoteLookupDto>> GetList(Guid UserId)
    {
        var query = new GetNoteListQuery()
        {
            UserId = UserId
        };

        var vm = (await _mediator.Send(query))
            .Notes
            .OrderByDescending(p => p.EditDate).ToList();

        return vm;
    }

    public async Task Add(CombineNoteVmFolderListVm vm, Guid UserId)
    {
        var query = new CreateNoteCommand
        {
            UserId = UserId,
            Text = vm.NoteVm.Text,
            Title = vm.NoteVm.Title,
            FolderId = vm.NoteVm?.Folder
        };

        await _mediator.Send(query);
    }

    public async Task<CombineNoteLookupFolder> GetNotesInFolder(Guid id, Guid UserId)
    {
        var noteList = (await GetList(UserId))
            .Where(f => f.FolderId == id)
            .ToList();

        var folder = await _folderService.Get(id, UserId);

        var vm = new CombineNoteLookupFolder
        {
            FolderVm = folder,
            NoteLookupDto = noteList
        };

        return vm;
    }
}