using Rental.Data.Facade;
using Rental.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rental.Data
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(RentalContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.RentalStatus.Any())
            {
                return;   // DB has been seeded
            }

            List<RentalStatus> rentalStatus = new List<RentalStatus>
            {
                new RentalStatus {Id = 1, UserId = 1, BookId = 1, Rented = true, Reserve = false, ReservedTime = null },
                new RentalStatus {Id = 2, UserId = 1, BookId = 3, Rented = true, Reserve = false, ReservedTime = null },
                new RentalStatus {Id = 3, UserId = 2, BookId = 4, Rented = true, Reserve = false, ReservedTime = null },
                new RentalStatus {Id = 4, UserId = 3, BookId = 3, Rented = false, Reserve = true, ReservedTime = System.DateTime.Now },
            };

            context.RentalStatus.AddRange(rentalStatus);
            context.SaveChanges();
        }
    }
}
