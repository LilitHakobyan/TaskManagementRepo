using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Models;

namespace TM.Data.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(string id);
    }
}
