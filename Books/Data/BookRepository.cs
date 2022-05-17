using Books.Data.Facade;
using Books.Models;
using System.Collections.Generic;
using System.Linq;

namespace Books.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db)
        {
            _db = db;
        }

        public Book getBook(int bookId)
        {
            var result = _db.Books.FirstOrDefault(x => x.Id == bookId);

            return result;
        }

        public List<Book> getBooks()
        {
            var result = new List<Book>(_db.Books);

            return result;
        }
    }
}
