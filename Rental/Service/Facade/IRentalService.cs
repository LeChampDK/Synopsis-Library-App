using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using System.Collections.Generic;

namespace Rental.Service.Facade
{
    public interface IRentalService
    {
        List<RentalStatus> GetAllRentalStatus();
    }
}
