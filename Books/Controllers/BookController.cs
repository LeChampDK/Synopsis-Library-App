using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {

        /// <summary>
        /// Get Book
        /// </summary>
        /// <remarks>
        /// Returns the user
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetBook()
        {
            return Ok("HERRY POTTAH");
        }
    }
}
