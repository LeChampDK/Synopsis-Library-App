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
    public class APIGatewayController : Controller
    {
        private readonly IAPIGatewayService _gatewayService;

        public APIGatewayController(IAPIGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentalStatusDTO>>> GetRentalStatusAsync()
        {
            var result = await _gatewayService.GetRentalStatusAsync();

            return result;
        }
    }
}
