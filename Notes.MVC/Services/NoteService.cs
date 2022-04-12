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
    
    public async Task Update(NoteVM noteVm, Guid UserId)
    {
        var command = new UpdateNoteCommand()
        {
            Id = noteVm.Id,
            Title = noteVm.Title,
            Text = noteVm.Text,
            UserId = UserId,
            FolderId = noteVm.Folder!.Value
        };

        await _mediator.Send(command);
    }

    public async Task<NoteListVm> GetList(Guid UserId)
    {
        var query = new GetNoteListQuery()
        {
            UserId = UserId
        };

        var vm = await _mediator.Send(query);

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
            .Notes
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