using Microsoft.AspNetCore.Mvc;
using TaskManagmentApplication.Application.Interfaces.Service;

namespace TaskManagmentApplication.MVC.Controllers
{
    public class TaskOwnersController : Controller
    {
        private readonly IAssignerService _assignerService;

        public TaskOwnersController(IAssignerService assignerService)
        {

            _assignerService = assignerService;
        }

        public async Task<IActionResult> GetOwners(int id)
        {
            var owners = await _assignerService.GetAssignersbyTaskId(id);
            return View(owners);
        }
    }
}
