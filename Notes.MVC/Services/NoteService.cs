using MediatR;
using Notes.Application.CommandsQueries.Notes.Commands.CreateNote;
using Notes.Application.CommandsQueries.Notes.Commands.ToTrash;
using Notes.Application.CommandsQueries.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.MVC.Models;
using Notes.Persistence;

namespace Notes.MVC.Services;

public class NoteService
{
    private readonly IMediator _mediator;
    private readonly FolderService _folderService;
    private readonly NoteDbContext _context;

    public NoteService(IMediator mediator, FolderService folderService, NoteDbContext context)
    {
        _mediator = mediator;
        _folderService = folderService;
        _context = context;
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

    public async Task Delete(Guid id, Guid userId)
    {
        var query = new DeleteNoteCommand
        {
            Id = id,
            UserId = userId
        };

        await _mediator.Send(query);
    }

    public async Task ToTrash(Guid id, Guid userId)
    {
        var query = new UpdateNoteCommand
        {
            Id = id
        };

        await _mediator.Send(query);
    }
    
    public async Task Update(CombineNoteVmFolderListVm vm, Guid userId)
    {
        var command = new UpdateNoteCommand()
        {
            Id = vm.NoteVm!.Id,
            Title = vm.NoteVm.Title!,
            Text = vm.NoteVm.Text!,
            UserId = userId,
            FolderId = vm.NoteVm.Folder!.Value
        };

        await _mediator.Send(command);
    }

    public async Task<List<NoteLookupDto>> GetList(Guid userId)
    {
        var query = new GetNoteListQuery()
        {
            UserId = userId
        };

        var vm = (await _mediator.Send(query)).Notes
            .Where(n => n.isDeleted == false)
            .OrderByDescending(p => p.EditDate).ToList();

        return vm;
    }

    public async Task<List<NoteLookupDto>> GetDeletedList(Guid userId)
    {
        var query = new GetNoteListQuery()
        {
            UserId = userId
        };

        var vm = (await _mediator.Send(query)).Notes
            .Where(n => n.isDeleted)
            .OrderByDescending(p => p.EditDate).ToList();

        return vm;
    }

    public async Task Add(CombineNoteVmFolderListVm vm, Guid userId)
    {
        var query = new CreateNoteCommand
        {
            UserId = userId,
            Text = vm.NoteVm!.Text!,
            Title = vm.NoteVm.Title!,
            FolderId = vm.NoteVm?.Folder
        };

        await _mediator.Send(query);
    }

    public async Task<CombineNoteLookupFolder> GetNotesInFolder(Guid id, Guid userId)
    {
        var noteList = GetList(userId)
            .Result
            .Where(f => f.FolderId == id)
            .ToList();

        var folder = await _folderService.Get(id, userId);

        var vm = new CombineNoteLookupFolder
        {
            FolderVm = folder,
            NoteLookupDto = noteList
        };

        return vm;
    }

    public async Task NoteToTrash(Guid id)
    {
        var query = new ToTrashCommand
        {
            Id = id
        };

        await _mediator.Send(query);
    }

    public async Task DeleteRange(IEnumerable<NoteLookupDto> noteList)
    {
        
    }
}