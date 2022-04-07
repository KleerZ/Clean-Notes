using AspNetCore.Unobtrusive.Ajax;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Services.Services;

namespace Notes.MVC.Controllers.Notes;

public class NoteController : BaseController
{
    private readonly NoteService _noteService;

    public NoteController(NoteService noteService) =>
        _noteService = noteService;

    [HttpGet]
    public async Task<IActionResult> EditPage(Guid id)
    {
        var note = await _noteService.Get(id, UserId);

        if (!Request.IsAjaxRequest())
            return RedirectToAction("Index", "Home", new {id = id});
            
        return PartialView("~/Views/Notes/_NoteEditPartial.cshtml", note);
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _noteService.Delete(id, UserId);
        
        return RedirectToAction("GetNotes", "NoteList");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(NoteVM noteVm)
    {
        await _noteService.Update(noteVm, UserId);

        return RedirectToAction("Index", "Home");
    }
}