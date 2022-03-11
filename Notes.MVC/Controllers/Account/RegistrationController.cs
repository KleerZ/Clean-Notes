using Microsoft.AspNetCore.Mvc;

namespace Notes.MVC.Controllers.Account;

public class RegistrationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Account/Registration.cshtml");
    }
}