using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;
using Notes.MVC.Models;
using Notes.MVC.Services;
using Notes.Persistence;

namespace Notes.MVC.Controllers.Folders;

public class FolderController : BaseController
{
    private readonly FolderService _folderService;
    
    public FolderController(FolderService folderService, NoteDbContext dbContext) =>
        _folderService = folderService;

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
}