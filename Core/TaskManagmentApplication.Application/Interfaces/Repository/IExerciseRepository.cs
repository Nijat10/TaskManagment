using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Application.Interfaces.Repository
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllTaskAsync();
        Task<Exercise> GetTaskByIdAsync(int id);
        Task AddTaskAsync(Exercise exercise);
        Task DeleteTaskByIdAsync(int id);
        Task UpdateTaskAsync(Exercise exercise);

    }
}
