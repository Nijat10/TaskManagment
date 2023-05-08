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
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AuthRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await applicationDbContext.Users.AddAsync(user);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            var selected = await applicationDbContext.Users.FirstOrDefaultAsync(e => e.Email == user.Email);
            if (selected != null)
            {
                applicationDbContext.Users.Remove(selected);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task EditUserAsync(User user)
        {
            applicationDbContext.Users.Update(user);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await applicationDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var selected = await applicationDbContext.Users.FirstOrDefaultAsync(e => e.Email == email);
            if (selected != null)
            {
                return selected;
            }
            return null;
        }
    }
}
