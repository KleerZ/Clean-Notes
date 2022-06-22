using Microsoft.AspNetCore.Mvc;
using Notes.Application.Interfaces;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers.Trash;

public class TrashController: BaseController
{
    private readonly NoteService _noteService;
    private readonly TrashService _trashService;
    private readonly INotesDbContext _context;
    
    public TrashController(NoteService noteService, TrashService trashService, INotesDbContext context)
    {
        _noteService = noteService;
        _trashService = trashService;
        _context = context;
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
    
    [HttpGet]
    public async Task<IActionResult> TaskTrash()
    {
        var tasks = _context.Tasks
            .Where(i => i.isDeleted == true && i.UserId == UserId)
            .ToList();

        return PartialView("~/Views/Trash/_TrashTaskPartial.cshtml", tasks);
    }
    
    [HttpPost]
    public async Task<IActionResult> RestoreTaskFromTrash(Guid id)
    {
        await _trashService.Restore(id);

        var notes = await _noteService.GetDeletedList(UserId);

        return PartialView("~/Views/Trash/_TrashPartial.cshtml", notes);
    }
}