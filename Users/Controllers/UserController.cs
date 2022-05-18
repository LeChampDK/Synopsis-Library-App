using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Service.Facade;

namespace Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers")]
        public ActionResult<User> GetUser()
        {
            var result = _userService.GetUsers();
            return Ok(result);
        }
    }
}
