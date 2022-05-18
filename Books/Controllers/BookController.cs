using Books.Models;
using Books.Service.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        /// Get Books - Returns all books
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBooks")]
        public ActionResult<List<Book>> GetBook()
        {
            var result = _bookService.getBooks();
            return Ok(result);
        }
    }
}
