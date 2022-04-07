using Microsoft.AspNetCore.Mvc;
using Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;
using Notes.MVC.Models;

namespace Notes.MVC.Controllers.Folders;

public class FolderController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CombineNoteFolderViewModel model)
    {
        if (model.Folder.Name == null)
        {
            return RedirectToAction("Index", "Home", model);
        }   
        
        var query = new CreateFolderCommand()
        {
            UserId = UserId,
            Name = model.Folder.Name
        };
        
        var folder = await Mediator.Send(query);
        
        return RedirectToAction("Index", "Home");
    }
}