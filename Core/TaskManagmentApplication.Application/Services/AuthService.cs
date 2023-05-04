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
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public async Task AddUserAsync(User user)
        {
            await authRepository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await authRepository.DeleteUserAsync(user);
        }

        public async Task EditUserAsync(User user)
        {
            await authRepository.EditUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await authRepository.GetAllUsersAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return authRepository.GetUserByEmailAsync(email);
        }
    }
}
