using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Service.Facade
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(int Id);
    }
}
