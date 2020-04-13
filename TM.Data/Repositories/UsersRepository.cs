using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TM.Data.Interfaces;
using TM.Data.Models;

namespace TM.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _dbContext;

        public UsersRepository(ApplicationContext context)
        {
            _dbContext = context;
        }
        public async Task<User> GetUserById(string id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
