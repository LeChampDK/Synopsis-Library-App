using System.Linq;
using System.Threading.Tasks;
using Users.Data.Facade;
using Users.Models;

namespace Users.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _db;

        public UserRepository(UserContext db)
        {
            _db = db;
        }

        public User GetUser(int Id)
        {
            var result = _db.Users.FirstOrDefault(x => x.Id == Id);

            return result;
        }
    }
}
