using Global.Models;
using Global.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using Rental.Models.DTO;
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
        /// Get Rental Status - Testing purpose only
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
        public async Task<ActionResult<BookQuantity>> GetBookAsync(int bookId)
        {
            return await _rentalService.GetBook(bookId);
        }

        [HttpPost("RentBook")]
        public async Task<ActionResult<RentalResponseDTO>> RentBook(RentBookDTO rentBookDTO)
        {
            return await _rentalService.RentBook(rentBookDTO);
        }
    }
}
