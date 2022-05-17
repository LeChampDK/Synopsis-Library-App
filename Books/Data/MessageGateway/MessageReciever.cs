using Books.Models;
using Books.Service.Facade;
using EasyNetQ;
using Global.Messages.Request;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Books.Data.MessageGateway
{
    public class MessageReciever
    {
        IServiceProvider _provider;
        string _connectionString;
        IBus _bus;

        public MessageReciever(IServiceProvider provider, string connectionString)
        {
            _provider = provider;
            _connectionString = connectionString;
        }

        public void Start()
        {
            using (_bus = RabbitHutch.CreateBus(_connectionString))
            {
                _bus.PubSub.Subscribe<BookServiceReceive>("BookMicroService", msg => ProcessMessage(msg));

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private void ProcessMessage(BookServiceReceive msg)
        {
            using (var scope = _provider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _bookService = service.GetService<IBookService>();
                var _messageProducer = service.GetService<MessageProducer>();

                var result = _bookService.getBook(msg.BookId);

                if (result == null)
                    throw new Exception("Book not found");

                _messageProducer.BookResponse(result);
            }
        }
    }
}
