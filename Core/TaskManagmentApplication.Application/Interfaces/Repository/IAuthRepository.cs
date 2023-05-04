using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Domain.Entities;

namespace TaskManagmentApplication.Application.Interfaces.Repository
{
    public interface IAuthRepository
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task EditUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email);    
    }
}
