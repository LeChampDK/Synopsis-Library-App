using APIGateway.Service.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
