using Microsoft.AspNetCore.Mvc;

namespace Notes.MVC.Controllers.Account;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Account/Login.cshtml");
    }
}