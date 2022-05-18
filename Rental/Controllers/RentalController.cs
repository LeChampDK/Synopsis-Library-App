using Global.Models;
using Global.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using Rental.Models.DTO;
using Rental.Service.Facade;
using System;
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

        /// <summary>
        /// Rent book
        /// </summary>
        /// <param name="rentBookDTO"></param>
        /// <returns></returns>
        [HttpPost("RentBook")]
        public async Task<ActionResult<string>> RentBook(BookDTO rentBookDTO)
        {
            var result = await _rentalService.RentBook(rentBookDTO);
            if (result.Rented)
            {
                return Ok("The book has been rented.");
            }
            else
            {
                return Ok("The book has been reserved.");
            }
        }

        [HttpPut("Return Book")]
        public ActionResult<string> ReturnBook(BookDTO returnBookDTO)
        {
            try
            {
                _rentalService.ReturnBook(returnBookDTO);
                return Ok("Book returned successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
