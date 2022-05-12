using Books.Data.Facade;
using Books.Models;
using System.Collections.Generic;
using System.Linq;

namespace Books.Data
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(BookContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            List<Book> users = new List<Book>
            {
                new Book { Id = 1, Title = "HERRY POTAH", Author = "JK ROLLIN", Quantity = 5 },
                new Book { Id = 2, Title = "Moby Duck", Author = "Sailer Man", Quantity = 2 },
                new Book { Id = 3, Title = "Game of Tones", Author = "RR. mcDonald", Quantity = 1 },
                new Book { Id = 4, Title = "Lighting of the Lamp", Author = "Guy", Quantity = 7 },
            };

            context.Books.AddRange(users);
            context.SaveChanges();
        }
    }
}
