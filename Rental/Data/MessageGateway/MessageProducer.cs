using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
using Global.Models;
using Global.Models.DTO;
using Rental.Models;
using System;
using System.Threading.Tasks;

namespace Rental.Data.MessageGateway
{
    public class MessageProducer
    {
        IBus bus;

        public MessageProducer(string connectionString)
        {
            bus = RabbitHutch.CreateBus(connectionString);
        }

        public void Dispose()
        {
            bus.Dispose();
        }

        internal async Task<bool> getUser(int userId)
        {
            var message = new UserServiceRequest
            {
                UserId = userId
            };

            var result = await bus.Rpc.RequestAsync<UserServiceRequest, UserServiceResponse>(message);

            return result.UserExist;
        }

        internal async Task<BookQuantity> getBook(int id)
        {
            var message = new BookServiceRequest
            {
                BookId = id
            };

            var result = await bus.Rpc.RequestAsync<BookServiceRequest, BookServiceResponse>(message);

            return result.BookQuantity;
        }

        public async Task<BookDetailsDTO> GetBookDetails(int bookId)
        {
            var message = new BookDetailsRequest
            {
                BookId = bookId
            };

            var result = await bus.Rpc.RequestAsync<BookDetailsRequest, BookDetailsResponse>(message);

            return result.BookDetails;
        }

        public void SendReservationNotice(BookDetailsDTO bookDetails, int userId)
        {
            var request = new ReservationNotificationRequest
            {
                BookDetails = bookDetails,
                UserId = userId
            };

            bus.PubSub.Publish(request);
        }
    }
}
