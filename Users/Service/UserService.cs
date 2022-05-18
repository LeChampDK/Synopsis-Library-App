using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Data.Facade;
using Users.Models;
using Users.Service.Facade;

namespace Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int Id)
        {
            return _userRepository.GetUser(Id);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
