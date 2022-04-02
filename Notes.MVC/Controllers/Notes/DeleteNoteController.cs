using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.DeleteNote;

namespace Notes.MVC.Controllers.Notes;

public class DeleteNoteController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> DeleteNote(Guid id)
    {
        var query = new DeleteNoteCommand()
        {
            Id = id,
            UserId = UserId
        };

        await Mediator.Send(query);
        
        return RedirectToAction("Index", "Home");
    }
}