using System.Security.Claims;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Domain;
using Notes.Identity;
using Notes.Identity.Models;
using Notes.MVC.Models;
using Notes.Services.Services;

namespace Notes.MVC.Controllers;

public class HomeController : BaseController
{
    private readonly NoteService _noteService;

    public HomeController(NoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<IActionResult> Index(Guid id)
    {
        var note = await _noteService.Get(id, UserId);

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
            CombineNoteVmFolderListVm = new CombineNoteVmFolderListVm
            {
                NoteVm = note, 
                FolderListVm = folders
            }
        };
        
        return View("~/Views/Home/Index.cshtml", model);
    }
}