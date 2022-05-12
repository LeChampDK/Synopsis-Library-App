using Books.Data.Facade;
using Books.Models;
using System.Collections.Generic;

namespace Books.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db)
        {
            _db = db;
        }

        public List<Book> getBooks()
        {
            var result = new List<Book>(_db.Books);

            return result;
        }
    }
}
