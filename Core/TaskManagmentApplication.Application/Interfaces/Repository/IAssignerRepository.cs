using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Application.Interfaces.Repository
{
    public interface IAssignerRepository
    {
        Task<List<User>> GetAssignersbyTaskId(int taskID);
        Task AddAssignerTask(int taskId, int userId);
    }
}
