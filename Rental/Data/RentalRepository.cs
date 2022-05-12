using Rental.Data.Facade;
using Rental.Models;
using System.Collections.Generic;

namespace Rental.Data
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalContext _db;

        public RentalRepository(RentalContext db)
        {
            _db = db;
        }

        public List<RentalStatus> GetAllRentalStatus()
        {
            return new List<RentalStatus>(_db.RentalStatus);
        }
    }
}
