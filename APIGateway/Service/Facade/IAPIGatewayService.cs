using APIGateway.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGateway.Service.Facade
{
    public interface IAPIGatewayService
    {
        #region Rental
        Task<string> RentBook(BookDTO rentBookDTO);
        Task<string> ReturnBook(BookDTO returnBookDTO);
        #endregion

        #region Books
        Task<List<Book>> GetBooks();
        #endregion

        #region Users
        Task<List<User>> GetUsers();
        #endregion
    }
}
