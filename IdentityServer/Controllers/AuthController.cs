using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly IIdentityServerInteractionService _interactionService;

        //public AuthController(
        //    UserManager<IdentityUser> userManager,
        //    SignInManager<IdentityUser> signInManager,
        //    IIdentityServerInteractionService interactionService)
        //{
        //    this._userManager = userManager;
        //    this._signInManager = signInManager;
        //    this._interactionService = interactionService;
        //}



        //[HttpGet]
        //public IActionResult Login(string returnUrl)
        //{
        //    return this.View(new LoginViewModel { ReturnUrl = returnUrl });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    // check if the model is valid 

        //    var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        //    // ( chenge IsPersistent to true if you want to cookie not be deleted after close browser and 
        //    // be still remembered )

        //    if (result.Succeeded)
        //    {
        //        return Redirect(model.ReturnUrl);
        //    }

        //    return this.View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Logout(string logoutId)
        //{
        //    await _signInManager.SignOutAsync();

        //    var logoutRequest = await this._interactionService.GetLogoutContextAsync(logoutId);

        //    if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return Redirect(logoutRequest.PostLogoutRedirectUri);
        //}


        //[HttpGet]
        //public IActionResult Register(string returnUrl)
        //{
        //    return this.View(new RegisterViewModel { ReturnUrl = returnUrl });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = new IdentityUser(model.Username);


        //    var result = await this._userManager.CreateAsync(user, model.Password);
        //    await this._userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Role, "user"));

        //    // ( chenge IsPersistent to true if you want to cookie not be deleted after close browser and 
        //    // be still remembered )

        //    if (result.Succeeded)
        //    {
        //        await _signInManager.SignInAsync(user, false);
        //        return Redirect(model.ReturnUrl);
        //    }

        //    return this.View();
        //}
    }
}