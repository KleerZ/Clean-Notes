using Microsoft.AspNetCore.Mvc;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers.Trash;

public class TrashController: BaseController
{
    private readonly NoteService _noteService;
    private readonly TrashService _trashService;

    public TrashController(NoteService noteService, TrashService trashService)
    {
        _noteService = noteService;
        _trashService = trashService;
    }
    
    [HttpGet]
    public async Task<IActionResult> TrashPage()
    {
        var notes = await _noteService.GetDeletedList(UserId);

        return PartialView("~/Views/Trash/_TrashPartial.cshtml", notes);
    }
    
    [HttpPost]
    public async Task<IActionResult> RestoreFromTrash(Guid id)
    {
        await _trashService.Restore(id);

        var notes = await _noteService.GetDeletedList(UserId);

        return PartialView("~/Views/Trash/_TrashPartial.cshtml", notes);
    }
}