using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Application.Interfaces.Service
{
    public interface IAssignerService
    {
        Task<List<User>> GetAssignersbyTaskId(int taskID);
    }
}
