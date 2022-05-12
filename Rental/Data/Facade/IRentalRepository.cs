using Rental.Models;
using System.Collections.Generic;

namespace Rental.Data.Facade
{
    public interface IRentalRepository
    {
        List<RentalStatus> GetAllRentalStatus();
    }
}
