using Books.Models;
using System.Collections.Generic;

namespace Books.Service.Facade
{
    public interface IBookService
    {
        List<Book> getBooks();
        Book getBook(int bookId);
    }
}
