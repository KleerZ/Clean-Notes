using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteList;

namespace Notes.MVC.Controllers.Notes;

public class EditNoteController : BaseController
{
    [HttpGet]
    public async Task<PartialViewResult> Index(Guid id)
    {
        var query = new GetNoteListQuery()
        {
            UserId = UserId
        };
        
        var noteList = await Mediator.Send(query);

        var currentNote = noteList.Notes.FirstOrDefault(n => n.Id == id);

        return PartialView("~/Views/Notes/_NoteEditPartial.cshtml", currentNote);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditNote(NoteLookupDto lookupDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new UpdateNoteCommand()
        {
            Id = lookupDto.Id,
            Title = lookupDto.Title,
            Text = lookupDto.Text,
            UserId = UserId
        };

        await Mediator.Send(command);

        return RedirectToAction("Index", "Home");
    }
}