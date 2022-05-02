using Microsoft.AspNetCore.Mvc;
using Notes.MVC.Models;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers.Folders;

public class FolderController : BaseController
{
    private readonly FolderService _folderService;
    private readonly NoteService _noteService;
    
    public FolderController(FolderService folderService, NoteService noteService)
    {
        _folderService = folderService;
        _noteService = noteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var folderList = await _folderService.GetList(UserId);
        
        return PartialView("~/Views/Folders/_FoldersPartial.cshtml", folderList);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CombineNoteFolderViewModel vm)
    {   
        await _folderService.Add(vm.Folder.Name, UserId);
        
        var folderList = await _folderService.GetList(UserId);
        
        return PartialView("~/Views/Folders/_FoldersPartial.cshtml", folderList);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _folderService.Delete(id, UserId);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Rename(CombineNoteFolderViewModel vm)
    {
        var folderList = await _folderService.Rename(vm, UserId);
        
        return PartialView("~/Views/Folders/_FoldersPartial.cshtml", folderList);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetNotesInFolder(Guid id)
    {
        var vm = await _noteService.GetNotesInFolder(id, UserId);

        return PartialView("~/Views/Folders/_FolderNotesPartial.cshtml", vm);
    }
}