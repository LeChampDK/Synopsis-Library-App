using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rental.Service.Facade
{
    public interface IRentalService
    {
        List<RentalStatus> GetAllRentalStatus();
        List<RentalStatus> GetAllRentalStatusOnBook(int bookId);
        Task<bool> GetUser(int id);
        Task<int> GetBook(int id);
    }
}
