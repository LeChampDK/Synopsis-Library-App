using Microsoft.EntityFrameworkCore;
using Rental.Models;

namespace Rental.Data
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {

        }

        public DbSet<RentalStatus> RentalStatus { get; set; }
    }
}
