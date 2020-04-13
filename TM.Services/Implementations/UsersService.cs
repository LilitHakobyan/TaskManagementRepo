using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Interfaces;
using TM.Data.Models;
using TM.Data.Repositories;
using TM.Services.Interfaces;

namespace TM.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepositoryRepository;

        public UsersService()
        {
            _usersRepositoryRepository = new UsersRepository(new ApplicationContext());
        }

        public UsersService(IUsersRepository usersRepositoryRepository)
        {
            _usersRepositoryRepository = usersRepositoryRepository;
        }
        public async Task<User> GetUserById(string id)
        {
            return await _usersRepositoryRepository.GetUserById(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _usersRepositoryRepository.GetUsers();
        }
    }
}
