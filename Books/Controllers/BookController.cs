using Books.Service.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

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
            var result = _bookService.getBooks();
            return Ok(result);
        }
    }
}
