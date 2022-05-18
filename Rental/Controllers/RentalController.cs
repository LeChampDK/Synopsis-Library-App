using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using Rental.Service.Facade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        /// <summary>
        /// Get Rental Status
        /// </summary>
        /// <remarks>
        /// Returns the rental status
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<RentalStatus>> GetRentalStatus()
        {
            return _rentalService.GetAllRentalStatus();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<bool>> GetUserAsync(int id)
        {
            return await _rentalService.GetUser(id);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<int>> GetBookAsync(int bookId)
        {
            return await _rentalService.GetBook(bookId);
        }
    }
}
