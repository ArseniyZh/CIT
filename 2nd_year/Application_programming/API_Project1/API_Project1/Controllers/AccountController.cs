using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Project1.Data;
using API_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using API_Project1.utils;
using Microsoft.AspNetCore.Identity;

namespace API_Project1.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: account/register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: account/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Username = model.Username };

                // Используйте UserManager для создания пользователя с безопасным хешированием пароля
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Автоматический вход после регистрации
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        // GET: account/login
        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: account/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]  // Защита от CSRF-атак
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }


        // GET: account/logout
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            // Выход из системы
            await _signInManager.SignOutAsync();

            // Перенаправление на страницу после выхода, например, на главную страницу
            return RedirectToAction("Index", "Home");
        }

        // GET: account/profile
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Перенаправление на страницу входа, если пользователь не найден
                return RedirectToAction("Login", "Account");
            }

            var model = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio
            };

            return View(model);
        }


        // POST: account/profile
        [HttpPost("profile")]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Bio = model.Bio;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Profile updated successfully";
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

    }
}
