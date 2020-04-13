using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Data.Models;

namespace TM.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(string id);
    }
}
