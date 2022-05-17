using EasyNetQ;
using Global.Messages.Request;
using Rental.Models;

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
    }
}
