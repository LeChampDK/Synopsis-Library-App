using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
    }
}
