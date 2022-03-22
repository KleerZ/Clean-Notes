using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Identity.Models;
using Notes.MVC.Models.Account;

namespace Notes.Identity.Controllers;

public class AuthController: Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IIdentityServerInteractionService _interactionService;

    public AuthController(IIdentityServerInteractionService interactionService,
        UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) =>
        (_signInManager, _userManager, _interactionService) =
        (signInManager, userManager, interactionService);

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        var model = new LoginViewModel {ReturnUrl = returnUrl};
        
        return View("~/Views/Login.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View("~/Views/Login.cshtml", model);

        var user = await _userManager.FindByNameAsync(model.Login);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Данный пользователь не существует");
            return View("~/Views/Login.cshtml", model);
        }

        var result = await _signInManager.PasswordSignInAsync(model.Login,
            model.Password, false, false);

        if (result.Succeeded) 
            return Redirect(model.ReturnUrl);

        ModelState.AddModelError(string.Empty, "Ошибка входа");
        
        return View("~/Views/Login.cshtml", model);
    }

    [HttpGet]
    public IActionResult Register(string returnUrl)
    {
        var model = new RegistrationViewModel {ReturnUrl = returnUrl};
        
        return View("~/Views/Registration.cshtml", model);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationViewModel model)
    {
        if(!ModelState.IsValid)
            return View("~/Views/Registration.cshtml", model);

        var user = new AppUser
        {
            UserName = model.Login
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return Redirect(model.ReturnUrl);
        }
        
        ModelState.AddModelError(string.Empty, "Ошибка регистрации");
        
        return View("~/Views/Registration.cshtml", model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout(string id)
    {
        await _signInManager.SignOutAsync();
        var logoutRequest = await _interactionService.GetLogoutContextAsync(id);

        return Redirect(logoutRequest.PostLogoutRedirectUri);
    }
}