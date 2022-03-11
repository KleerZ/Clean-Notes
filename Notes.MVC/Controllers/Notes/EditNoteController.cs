using Microsoft.AspNetCore.Mvc;

namespace Notes.MVC.Controllers.AllNotes;

public class EditNoteController : Controller
{
    // GET
    public PartialViewResult Index()
    {
        return PartialView("~/Views/Notes/_NoteEditPartial.cshtml");
    }
}