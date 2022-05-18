using APIGateway.Models;
using APIGateway.Service.Facade;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGateway.Service
{
    public class APIGatewayService : IAPIGatewayService
    {
        private readonly IConfiguration _configuration;

        string booksConnectionString;
        string usersConnectionString;
        string rentalConnectionString; 

        public APIGatewayService(IConfiguration configuration)
        {
            _configuration = configuration;

            booksConnectionString = _configuration.GetConnectionString("Books");
            usersConnectionString = _configuration.GetConnectionString("Users");
            rentalConnectionString = _configuration.GetConnectionString("Rental");
        }

        #region Rental
        public async Task<string> RentBook(BookDTO rentBookDTO)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(rentalConnectionString + "RentBook");
            request.AddBody(rentBookDTO);

            var response = client.PostAsync<string>(request);
            response.Wait();
            return response.Result;
        }

        public async Task<string> ReturnBook(BookDTO returnBookDTO)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(rentalConnectionString + "ReturnBook");
            request.AddBody(returnBookDTO);

            var response = client.PutAsync<string>(request);
            response.Wait();
            return response.Result;
        }
        #endregion

        #region Books
        public async Task<List<Book>> GetBooks()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(booksConnectionString + "GetBooks");

            var response = client.GetAsync<List<Book>>(request);
            response.Wait();
            return response.Result;
        }
        #endregion

        #region Users
        public async Task<List<User>> GetUsers()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(usersConnectionString + "GetUsers");

            var response = client.GetAsync<List<User>>(request);
            response.Wait();
            return response.Result;
        }
        #endregion
    }
}
