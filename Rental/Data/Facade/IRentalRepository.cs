using Rental.Models;
using System.Collections.Generic;

namespace Rental.Data.Facade
{
    public interface IRentalRepository
    {
        List<RentalStatus> GetAllRentalStatus();
        List<RentalStatus> GetAllRentalStatusOnBook(int bookId);
        void ReserveBook(int bookId, int userId);
        void RentBook(int bookId, int userId);
        void ReturnBook(int bookId, int userId);
        List<RentalStatus> GetAllReservedStatusOnBook(int bookId);
    }
}
