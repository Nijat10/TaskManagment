using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.MVC.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddImage(int id)
        {
            ViewBag.TaskId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(IFormFile image, string taskid)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                    var imageEntity = new Image();
                    imageEntity.Taskid = Convert.ToInt32(taskid);
                    imageEntity.Imageurl = fileName;
                    await _imageService.AddImageAsync(imageEntity);
                    return Redirect($"/Exercises/TaskDetails/{taskid}");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImage(int taskID, int imageID)
        {
            if (imageID > 0)
            {
                var image = await _imageService.GetImageAsync(imageID);
                if (image != null)
                {
                    await _imageService.DeleteImageAsync(image);
                    return Redirect($"/Exercises/TaskDetails/{taskID.ToString()}");
                }
                return View();
            }
            return View();
        }
    }
}
