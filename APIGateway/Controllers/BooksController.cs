using APIGateway.Service.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IAPIGatewayService _gatewayService;

        public BooksController(IAPIGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }


    }
}
