using APIGateway.Models;
using APIGateway.Service.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IAPIGatewayService _gatewayService;

        public UsersController(IAPIGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var result = await _gatewayService.GetUsers();
            return Ok(result);

        }
    }
}
