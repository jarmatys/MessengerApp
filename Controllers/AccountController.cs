using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    public class AccountController : Controller
    {
        // Zaleśności do logowania i rejestracji użytkowników
        protected UserManager<IdentityUser> _userManager { get; }
        protected SignInManager<IdentityUser> _signInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewData)
        {
            // Sprawdzamy czy walidacja na modelu jest pozytywna
            if (ModelState.IsValid)
            {
                // Tworzymy użytkownika na podstawie przesłanych danych
                var user = new IdentityUser(viewData.Login) { Email = viewData.Email };
                var result = await _userManager.CreateAsync(user, viewData.Password);

                if (result.Succeeded)
                {
                    // Logujemy użytkownika z ustawieniem aby nie był zapamiętany za pierwszym razem
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewData);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewData)
        {
            // Sprawdzanie walidacji modelu
            if (ModelState.IsValid)
            {
                // Logowanie użytkownika
                var result = await _signInManager.PasswordSignInAsync(viewData.Login, viewData.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Nie można się zalogować!");
                }

            }
            return View(viewData);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}