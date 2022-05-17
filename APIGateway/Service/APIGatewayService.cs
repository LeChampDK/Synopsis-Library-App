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

        public async Task<List<RentalStatusDTO>> GetRentalStatusAsync()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(rentalConnectionString);
            
            var response = client.GetAsync<List<RentalStatusDTO>>(request);
            response.Wait();
            return response.Result;
        }
    }
}
