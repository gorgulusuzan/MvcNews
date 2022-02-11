using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcNews.Models;

namespace MvcNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;

        //dependency injection
        public AccountController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel { IsPersistent = true });
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.IsPersistent, true);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı girişi");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}