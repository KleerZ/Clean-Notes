using AspNetCore.Unobtrusive.Ajax;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Application.CommandsQueries.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.MVC.Models;
using Notes.Services.Services;

namespace Notes.MVC.Controllers.Notes;

public class NoteController : BaseController
{
    private readonly NoteService _noteService;
    private readonly FolderService _folderService;

    public NoteController(NoteService noteService, FolderService folderService)
    {
        _noteService = noteService;
        _folderService = folderService;
    }

    [HttpGet]
    public async Task<IActionResult> AddPage()
    {
        var folderList = await _folderService.GetList(UserId);
        var vm = new CombineNoteVmFolderListVm()
        {
            NoteVm = new NoteVM(),
            FolderListVm = folderList
        };
        
        return PartialView("~/Views/Notes/_NoteAddingPartial.cshtml", vm);
    }

    [HttpGet]
    public async Task<IActionResult> EditPage(Guid id)
    {
        var note = await _noteService.Get(id, UserId);
        var folderList = await _folderService.GetList(UserId);

        if (!Request.IsAjaxRequest())
            return RedirectToAction("Index", "Home", new {id = id});

        var vm = new CombineNoteVmFolderListVm()
        {
            NoteVm = note,
            FolderListVm = folderList
        };
            
        return PartialView("~/Views/Notes/_NoteEditPartial.cshtml", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CombineNoteVmFolderListVm vm)
    {
        var query = new CreateNoteCommand
        {
            UserId = UserId,
            Text = vm.NoteVm.Text,
            Title = vm.NoteVm.Title,
            FolderId = vm.NoteVm?.Folder
        };

        await Mediator.Send(query);
        
        return RedirectToAction("GetList", "Note");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _noteService.Delete(id, UserId);
        
        return RedirectToAction("GetList", "Note");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CombineNoteVmFolderListVm vm)
    {
        var note = new NoteVM
        {
            Id = vm.NoteVm.Id,
            Title = vm.NoteVm.Title,
            EditDate = DateTime.Now,
            Text = vm.NoteVm.Text,
            Folder = vm.NoteVm.Folder
        };
        
        await _noteService.Update(note, UserId);

        return RedirectToAction("GetList", "Note");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var vm = await _noteService.GetList(UserId);

        var sortedVm = vm?.Notes?
            .OrderByDescending(p => p.EditDate).ToList();

        return PartialView("~/Views/Notes/_NotesPartial.cshtml", sortedVm);
    }
}