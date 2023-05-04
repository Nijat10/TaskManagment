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
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        public async Task AddTaskAsync(Exercise exercise)
        {
            await exerciseRepository.AddTaskAsync(exercise);
        }

        public async Task DeleteTaskByIdAsync(int id)
        {
            await exerciseRepository.DeleteTaskByIdAsync(id);
        }

        public async Task<List<Exercise>> GetAllTaskAsync()
        {
           return await exerciseRepository.GetAllTaskAsync();
        }

        public async Task<Exercise> GetTaskByIdAsync(int id)
        {
          return  await exerciseRepository.GetTaskByIdAsync(id);
        }

        public async Task UpdateTaskAsync(Exercise exercise)
        {
            await exerciseRepository.UpdateTaskAsync(exercise);
        }
    }
}
