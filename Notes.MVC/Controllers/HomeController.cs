using Microsoft.AspNetCore.Mvc;
using Notes.MVC.Models;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers;

public class HomeController : BaseController
{
    private readonly NoteService _noteService;
    private readonly FolderService _folderService;

    public HomeController(NoteService noteService, FolderService folderService)
    {
        _noteService = noteService;
        _folderService = folderService;
    }

    public async Task<IActionResult> Index(Guid id)
    {
        var note = await _noteService.Get(id, UserId);
        var folders = await _folderService.GetList(UserId);
        var noteList = await _noteService.GetList(UserId);

        var model = new CombineNoteFolderViewModel()
        {
            NoteList = noteList.Notes,
            CombineNoteVmFolderListVm = new CombineNoteVmFolderListVm
            {
                NoteVm = note, 
                FolderListVm = folders
            }
        };
        
        return View("~/Views/Home/Index.cshtml", model);
    }
}