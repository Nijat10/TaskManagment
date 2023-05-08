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
        public async Task<List<User>> GetAssignersbyTaskId(int taskID)
        {
            var assigners =await applicationDbContext.Taskassigns
                              .Where(ta => ta.Taskid == taskID)
                              .Include(ta => ta.User)
                              .Select(ta => ta.User)
                              .ToListAsync();

            return assigners;

        }
    }
}
