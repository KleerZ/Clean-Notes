using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Tasks.Queries.GetTaskList;

namespace Notes.MVC.Controllers.Notes;

public class AllNotesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var query = new GetNoteListQuery()
        {
            UserId = UserId
        };

        var vm = await Mediator.Send(query);

        return PartialView("~/Views/Notes/_NotesPartial.cshtml", vm.Notes);
    }
}