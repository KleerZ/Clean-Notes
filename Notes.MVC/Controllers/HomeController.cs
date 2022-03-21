using Microsoft.AspNetCore.Mvc;

namespace Notes.MVC.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}