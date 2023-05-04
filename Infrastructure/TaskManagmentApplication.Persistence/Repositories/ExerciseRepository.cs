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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskByIdAsync(int id)
        {
            var task =await _context.Exercises.FirstOrDefaultAsync(e => e.Taskid == id);
            if (task != null)
            {
                 _context.Exercises.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Exercise>> GetAllTaskAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetTaskByIdAsync(int id)
        {
           return await _context.Exercises.FirstOrDefaultAsync(e => e.Taskid == id);
        }

        public async Task UpdateTaskAsync(Exercise exercise)
        {
            var task = await _context.Exercises.FirstOrDefaultAsync(e => e.Taskid == exercise.Taskid);
            if (task != null)
            {
                _context.Exercises.Update(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
