using Microsoft.AspNetCore.Mvc;
using Notes.Application.CommandsQueries.Notes.Commands.Restore;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers.Trash;

public class TrashController: BaseController
{
    private readonly NoteService _noteService;
    private readonly FolderService _folderService;

    public TrashController(NoteService noteService, FolderService folderService)
    {
        _noteService = noteService;
        _folderService = folderService;
    }
    
    [HttpGet]
    public async Task<IActionResult> TrashPage()
    {
        var notes = (await _noteService.GetDeletedList(UserId))
            .Where(n => n.isDeleted == true)
            .ToList();

        return PartialView("~/Views/Trash/_TrashPartial.cshtml", notes);
    }
    
    [HttpPost]
    public async Task<IActionResult> RestoreFromTrash(Guid id)
    {
        var query = new RestoreCommand
        {
            Id = id
        };

        await Mediator.Send(query);

        var notes = await _noteService.GetDeletedList(UserId);

        return PartialView("~/Views/Trash/_TrashPartial.cshtml", notes);
    }
}