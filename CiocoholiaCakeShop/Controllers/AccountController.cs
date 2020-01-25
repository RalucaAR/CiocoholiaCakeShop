using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiocoholiaCakeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CiocoholiaCakeShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Login account)
        {
            IdentityUser user = null;
            if (account.Password != null)
            {
                user = await _userManager.FindByNameAsync(account.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, account.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(account);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, string.Empty);
                return View(account);
            }
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromForm] Register register)
        {
            var user = new IdentityUser
            {
                Email = register.Email,
                UserName = register.UserName
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return await Login(new Login
                {
                    UserName = register.UserName,
                    Password = register.Password
                });

            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }


    }
}