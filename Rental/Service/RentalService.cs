using Microsoft.AspNetCore.Mvc;
using Rental.Data.Facade;
using Rental.Data.MessageGateway;
using Rental.Models;
using Rental.Models.DTO;
using Rental.Service.Facade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rental.Service
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly MessageProducer _messageProducer;

        public RentalService(IRentalRepository rentalRepository, MessageProducer messageProducer)
        {
            _rentalRepository = rentalRepository;
            _messageProducer = messageProducer;
        }

        public List<RentalStatus> GetAllRentalStatus()
        {
            return _rentalRepository.GetAllRentalStatus();
        }

        public List<RentalStatus> GetAllRentalStatusOnBook(int bookId)
        {
            return _rentalRepository.GetAllRentalStatusOnBook(bookId);
        }

        public async Task<int> GetBook(int id)
        {
            var result = await _messageProducer.getBook(id);

            return result;
        }

        public async Task<bool> GetUser(int id)
        {
            var result = await _messageProducer.getUser(id);

            return result;
        }
    }
}
