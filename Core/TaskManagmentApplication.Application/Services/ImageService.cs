using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Application.Interfaces.Repository;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task AddImageAsync(Image image)
        {
            await imageRepository.AddImageAsync(image);
        }

        public async Task DeleteImageAsync(Image image)
        {
            await imageRepository.DeleteImageAsync(image);
        }

        public async Task<List<Image>> GetAllImagesAsync(int taskId)
        {
            return await imageRepository.GetAllImagesAsync(taskId);
        }

        public async Task<Image> GetImageAsync(int imageID)
        {
            return await imageRepository.GetImageAsync(imageID);

        }
    }
}
