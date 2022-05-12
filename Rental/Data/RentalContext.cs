using Microsoft.EntityFrameworkCore;

namespace Rental.Data
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {

        }
    }
}
