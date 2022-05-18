using System.Collections.Generic;
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
            return _db.Users.FirstOrDefault(x => x.Id == Id);
        }
        
        public List<User> GetUsers()
        {
            var result = new List<User>(_db.Users);
            return result;
        }
    }
}
