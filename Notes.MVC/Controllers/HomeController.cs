using System.Security.Claims;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Identity;
using Notes.Identity.Models;
using Notes.MVC.Models;

namespace Notes.MVC.Controllers;

public class HomeController : BaseController
{
    public async Task<IActionResult> Index(Guid id)
    {
        var query = new GetNoteQuery
        {
            Id = id,
            UserId = UserId
        };

        var note = await Mediator.Send(query);

        var query2 = new GetFolderListQuery
        {
            UserId = UserId
        };

        var folders = await Mediator.Send(query2);
        
        var query3 = new GetNoteListQuery()
        {
            UserId = UserId
        };

        var noteList = (await Mediator.Send(query3)).Notes;

        var model = new CombineNoteFolderViewModel()
        {
            NoteList = noteList,
            NoteVm = note,
            FolderList = folders
        };
        
        return View("~/Views/Home/Index.cshtml", model);
    }
}