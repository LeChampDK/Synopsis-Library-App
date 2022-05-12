using Books.Data.Facade;
using Books.Models;
using Books.Service.Facade;
using System.Collections.Generic;

namespace Books.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> getBooks()
        {
            var result = _bookRepository.getBooks();

            return result;
        }
    }
}
