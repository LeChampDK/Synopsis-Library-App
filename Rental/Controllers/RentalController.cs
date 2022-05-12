using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using Rental.Service.Facade;
using System.Collections.Generic;

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
    }
}
