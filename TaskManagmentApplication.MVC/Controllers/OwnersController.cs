using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Application.Services;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.MVC.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class OwnersController : Controller
    {
        private readonly IAuthService authService;

        public OwnersController(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await authService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditOwner(string email)
        {
            var selected = await authService.GetUserByEmailAsync(email);
            if (selected != null)
            {
                return View(selected);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOwner(string email)
        {
            var selected = await authService.GetUserByEmailAsync(email);
            if (selected != null)
            {
                await authService.DeleteUserAsync(selected);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditOwner(User user)
        {
            var selectedUser =await authService.GetUserByEmailAsync((string)user.Email);


            user.Email = selectedUser.Email;
            user.Id = selectedUser.Id;
            user.Password = selectedUser.Confirmpassword;
            user.Confirmpassword = selectedUser.Confirmpassword;

            if (ModelState.IsValid)
            {
                await authService.EditUserAsync(selectedUser);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
