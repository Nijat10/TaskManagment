using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Domain.Entities;

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

        [HttpPost]
        public async Task<IActionResult> AssignUser(string assignerId, string taskId)
        {
            if(!string.IsNullOrEmpty(assignerId)&& !string.IsNullOrEmpty(taskId))
            {
                await _assignerService.AddAssignerTask(Convert.ToInt32(taskId), Convert.ToInt32(assignerId));
            }
            
            return RedirectToAction("TaskDetails","Exercises", new { id = taskId });
        }


    }
}
