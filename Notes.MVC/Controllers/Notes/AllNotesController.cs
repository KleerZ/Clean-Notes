using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Notes.MVC.Controllers.AllNotes;

public class AllNotesController : Controller
{
    public PartialViewResult Index()
    {
        return PartialView("~/Views/Notes/_NotesPartial.cshtml");
    }
}