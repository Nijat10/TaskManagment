using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Application.Services;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.MVC.Controllers
{
    [Authorize]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly IAssignerService _assignerService;
        private readonly IImageService _imageService;

        public ExercisesController(IExerciseService exerciseService, IImageService imageService, IAssignerService assignerService)
        {
            _exerciseService = exerciseService;
            _imageService = imageService;
            _assignerService = assignerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _exerciseService.GetAllTaskAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                await _exerciseService.AddTaskAsync(exercise);
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var selected = await _exerciseService.GetTaskByIdAsync(id);
            if (selected != null)
            {
                return View(selected);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var selected = await _exerciseService.GetTaskByIdAsync(id);
            if (selected != null)
            {
                await _exerciseService.DeleteTaskByIdAsync(id);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                await _exerciseService.UpdateTaskAsync(exercise);
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        [HttpGet]
        public async Task<IActionResult> TaskDetails(int id)
        {
            var task = await _exerciseService.GetTaskByIdAsync(id);
            if (task != null)
            {
                ViewBag.Images = await _imageService.GetAllImagesAsync(id);
                var owners = await _assignerService.GetAssignersbyTaskId(id);
                string ownerNames = string.Empty;
                if (owners != null && owners.Count > 0)
                {
                    ownerNames = string.Join(',', owners.Select(o => o.Email));
                }

                ViewBag.OwnerNames = ownerNames;
                return View(task);

            }
            return View("Index");
        }
    }
}
