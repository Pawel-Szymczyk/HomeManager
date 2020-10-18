using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return this.View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // check if the model is valid 

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            // ( chenge IsPersistent to true if you want to cookie not be deleted after close browser and 
            // be still remembered )

            if(result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            return this.View();
        }


        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return this.View(new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser(model.Username);
            var result = await this._userManager.CreateAsync(user, model.Password);
           
            // ( chenge IsPersistent to true if you want to cookie not be deleted after close browser and 
            // be still remembered )

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(model.ReturnUrl);
            }

            return this.View();
        }
    }
}