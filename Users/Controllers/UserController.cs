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
        /// <remarks>
        /// Returns the user
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public ActionResult<User> GetUser(int Id)
        {
            var result = _userService.GetUser(Id);
            return Ok(result);
        }
    }
}
