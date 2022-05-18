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
    public class BooksController : Controller
    {
        private readonly IAPIGatewayService _gatewayService;

        public BooksController(IAPIGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var result = await _gatewayService.GetBooks();
            return Ok(result);

        }
    }
}
