using Rental.Data.Facade;
using Rental.Data.MessageGateway;
using Rental.Models;
using Rental.Models.DTO;
using Rental.Service.Facade;
using System.Collections.Generic;

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

        public BookRentalDTO RentBook(int userId)
        {
            bool userExist = _messageProducer.getUser(userId);
        }
    }
}
