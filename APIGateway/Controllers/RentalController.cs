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
    public class RentalController : Controller
    {
        private readonly IAPIGatewayService _gatewayService;

        public RentalController(IAPIGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        /// <summary>
        /// Rent a book - If the book is not available, it will be reserved.
        /// </summary>
        /// <param name="rentBookDTO"></param>
        /// <returns></returns>
        [HttpPost("RentBook")]
        public async Task<ActionResult<string>> RentBook(BookDTO rentBookDTO)
        {
            var result = await _gatewayService.RentBook(rentBookDTO);
            return Ok(result);
        }

        /// <summary>
        /// Return book - If any book is reserved, will notify the next user.
        /// </summary>
        /// <param name="returnBookDTO"></param>
        /// <returns></returns>
        [HttpPut("ReturnBook")]
        public async Task<ActionResult<string>> ReturnBook(BookDTO returnBookDTO)
        {

            var result = await _gatewayService.ReturnBook(returnBookDTO);
            return Ok(result);

        }
    }
}
