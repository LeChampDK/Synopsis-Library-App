using System.Threading.Tasks;
using Users.Models;

namespace Users.Data.Facade
{
    public interface IUserRepository
    {
        User GetUser(int Id);
    }
}
