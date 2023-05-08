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
    public class AssignerRepository : IAssignerRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AssignerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddAssignerTask(int taskId, int userId)
        {
            var task = applicationDbContext.Exercises
            .Include(t => t.Taskassigns)
        .Single(t => t.Taskid == taskId);

            var assigner = applicationDbContext.Users
            .Single(a => a.Id == userId);

            task.Taskassigns.Add(new Taskassign { Task = task, User = assigner });

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAssignersbyTaskId(int taskID)
        {
            var assigners = await applicationDbContext.Taskassigns
                              .Where(ta => ta.Taskid == taskID)
                              .Include(ta => ta.User)
                              .Select(ta => ta.User)
                              .ToListAsync();

            return assigners;

        }
    }
}
