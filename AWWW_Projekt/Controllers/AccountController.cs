using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWWW_Projekt.Services;
using AWWW_Projekt.ViewModels.IdentityViewModels;

namespace AWWW_Projekt.Controllers
{
    public class AccountController : Controller
    {
        private AccountServices accountService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _usermanager,
            SignInManager<IdentityUser> _signInManager)
        {
            userManager = _usermanager;
            signInManager = _signInManager;
        }
        [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("index", "home");
    }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
