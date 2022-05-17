using Books.Models;
using Books.Service.Facade;
using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
using Global.Models;
using System;
using System.Threading;

namespace Books.Data.MessageGateway
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

        internal void BookResponse(Book result)
        {
            var message = new BookServiceResponse
            {
                BookId = result.Id,
                MaxQuantity = result.Quantity,
            };

            bus.PubSub.Publish(message);
        }
    }
}
