using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Notes.MVC.Controllers;

public class LogoutController : Controller
{
    [HttpPost]
    public IActionResult Logout()
    {
        foreach (var cookie in Request.Cookies.Keys) 
            Response.Cookies.Delete(cookie);

        return RedirectToAction("Index", "Home");
    }
}