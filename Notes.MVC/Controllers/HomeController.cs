using System.Security.Claims;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Identity;
using Notes.Identity.Models;

namespace Notes.MVC.Controllers;

public class HomeController : Controller
{
    private readonly Configuration _configuration;
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
}