using Books.Models;
using System.Collections.Generic;

namespace Books.Data.Facade
{
    public interface IBookRepository
    {
        List<Book> getBooks();
    }
}
