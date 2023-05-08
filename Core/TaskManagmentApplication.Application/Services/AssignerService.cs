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
    public class AssignerService : IAssignerService
    {
        private readonly IAssignerRepository _assignerRepository;

        public AssignerService(IAssignerRepository assignerRepository)
        {
            _assignerRepository = assignerRepository;
        }
        public async Task<List<User>> GetAssignersbyTaskId(int taskID)
        {
            return await _assignerRepository.GetAssignersbyTaskId(taskID);    
        }
    }
}
