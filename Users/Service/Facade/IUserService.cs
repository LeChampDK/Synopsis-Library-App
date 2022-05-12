using System.Threading.Tasks;
using Users.Models;

namespace Users.Service.Facade
{
    public interface IUserService
    {
        User GetUser(int Id);
    }
}
