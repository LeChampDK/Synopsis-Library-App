using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
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

        internal void getBookDetails(int BookId)
        {
            var message = new BookServiceReceive
            {
                BookId = BookId
            };

            bus.PubSub.Publish(message);
        }

        internal async Task<bool> getUser(int userId)
        {
            var message = new UserServiceReceive
            {
                UserId = userId
            };

            var result = await bus.Rpc.RequestAsync<UserServiceReceive, UserServiceResponse>(message);

            return result.UserExist;
        }

        internal async Task<int> getBook(int id)
        {
            var message = new BookServiceReceive
            {
                BookId = id
            };

            var result = await bus.Rpc.RequestAsync<BookServiceReceive, BookServiceResponse>(message);

            return result.BookId;
        }
    }
}
