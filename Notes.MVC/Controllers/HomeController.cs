using System.Security.Claims;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Identity;
using Notes.Identity.Models;

namespace Notes.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    { 
        
        
        return View();
    }
}