using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Application.Interfaces.Service
{
    public interface IImageService
    {
        Task AddImageAsync(Image image);
        Task DeleteImageAsync(Image image);
        Task<List<Image>> GetAllImagesAsync(int taskId);
        Task<Image> GetImageAsync(int imageID);
    }
}
