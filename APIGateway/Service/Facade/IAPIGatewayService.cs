using APIGateway.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGateway.Service.Facade
{
    public interface IAPIGatewayService
    {
        Task<List<RentalStatusDTO>> GetRentalStatusAsync();
    }
}
