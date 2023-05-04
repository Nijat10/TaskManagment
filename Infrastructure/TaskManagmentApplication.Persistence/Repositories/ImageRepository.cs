using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Application.Interfaces.Repository;
using TaskManagmentApplication.Domain.Entities;
using TaskManagmentApplication.Persistence.DbContexts;

namespace TaskManagmentApplication.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAllImagesAsync(int taskId)
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetImageAsync(int imageID)
        {
            return await _context.Images.FirstOrDefaultAsync(i => i.Imageid == imageID);
        }
    }
}
