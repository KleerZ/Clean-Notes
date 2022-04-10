using Microsoft.AspNetCore.Mvc;
using Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;
using Notes.MVC.Models;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers.Folders;

public class FolderController : BaseController
{
    private readonly FolderService _folderService;
    public FolderController(FolderService folderService)
    {
        _folderService = folderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var folderList = await _folderService.GetList(UserId);
        
        return PartialView("~/Views/Folders/_FoldersPartial.cshtml", folderList);
    }

    [HttpPost]
    public async Task<IActionResult> Add()
    {
        var name = Request.Form["name"];
        
        await _folderService.Add(name, UserId);
        
        var folderList = await _folderService.GetList(UserId);
        
        return PartialView("~/Views/Folders/_FoldersPartial.cshtml", folderList);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _folderService.Delete(id, UserId);
        
        return RedirectToAction("Index", "Home");
    }
}