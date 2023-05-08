using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Domain.Entities;
using TaskManagmentApplication.MVC.ViewModels;

namespace TaskManagmentApplication.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("IsLogged", 0);
            HttpContext.Session.SetString("Role", "");
            return View();
        }

        public async Task<IActionResult> Login()
        {
            HttpContext.Session.SetInt32("IsLogged", 0);
            HttpContext.Session.SetString("Role", "");
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await authService.GetUserByEmailAsync(loginVM.UserName);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, loginVM.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("UserID", user.Id.ToString())
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), properties);

                this.HttpContext.Session.SetInt32("IsLogged", 1);
                this.HttpContext.Session.SetString("Role", user.Role);
                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }

        [HttpGet]
        public IActionResult SignUp()
        {

            this.HttpContext.Session.SetInt32("IsLogged", 0);
            this.HttpContext.Session.SetString("Role", "");
            return View();
        }

        [HttpPost]
        [ValidateDNTCaptcha(
            ErrorMessage = "Please Enter Valid Captcha",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public async Task<IActionResult> SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(user.Email) && await authService.GetUserByEmailAsync(user.Email) == null)
                {
                    await authService.AddUserAsync(user);
                }
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.SetInt32("IsLogged", 0);
            HttpContext.Session.SetString("Role", "");
            return RedirectToAction("Login", "Account");
        }
    }
}
