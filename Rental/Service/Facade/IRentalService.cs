using Global.Models;
using Global.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Rental.Models;
using Rental.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rental.Service.Facade
{
    public interface IRentalService
    {
        List<RentalStatus> GetAllRentalStatus();
        List<RentalStatus> GetAllRentalStatusOnBook(int bookId);
        Task<bool> GetUser(int id);
        Task<BookQuantity> GetBook(int id);
        Task<RentalResponseDTO> RentBook(BookDTO rentBookDTO);
        void ReturnBook(BookDTO returnBookDTO);
    }
}
