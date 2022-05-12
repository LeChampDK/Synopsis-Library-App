using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental.Data.Facade;

namespace Rental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : Controller
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        /// <summary>
        /// Get Rental Status
        /// </summary>
        /// <remarks>
        /// Returns the rental status
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetRentalStatus()
        {
            return Ok("Rental status: OK");
        }
    }
}
