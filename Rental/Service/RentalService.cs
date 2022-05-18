using Global.Models;
using Global.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Rental.Data.Facade;
using Rental.Data.MessageGateway;
using Rental.Models;
using Rental.Models.DTO;
using Rental.Service.Facade;
using System;
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

        

        public async Task<BookQuantity> GetBook(int id)
        {
            var result = await _messageProducer.getBook(id);

            return result;
        }

        public async Task<bool> GetUser(int id)
        {
            var result = await _messageProducer.getUser(id);

            return result;
        }

        public async Task<RentalResponseDTO> RentBook(BookDTO rentBookDTO)
        {
            var user = _messageProducer.getUser(rentBookDTO.UserId);
            var book = _messageProducer.getBook(rentBookDTO.BookId);

            var taskUser = await user;
            var taskBook = await book;

            var result = new RentalResponseDTO();

            if (!taskUser)
                throw new Exception("User does not exist");

            if (taskBook.Id <= 0)
                throw new Exception("Book does not exist");

            var bookRentalStatus = _rentalRepository.GetAllRentalStatusOnBook(taskBook.Id);

            if (bookRentalStatus.Count >= taskBook.Quantity)
            {
                _rentalRepository.ReserveBook(rentBookDTO.BookId, rentBookDTO.UserId);

                result.Reserved = true;

                return result;
            }
            else
            {
                _rentalRepository.RentBook(rentBookDTO.BookId, rentBookDTO.UserId);

                result.Rented = true;

                return result;
            }
        }

        public void ReturnBook(BookDTO returnBook)
        {
            _rentalRepository.ReturnBook(returnBook.BookId, returnBook.UserId);
        }
    }
}
