using Books.Models;
using Books.Service.Facade;
using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
using Global.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Books.MessageHandler
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
                _bus.Rpc.Respond<BookServiceReceive, BookServiceResponse>(msg => ProcessMessage(msg));

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private BookServiceResponse ProcessMessage(BookServiceReceive msg)
        {
            using (var scope = _provider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _bookService = service.GetService<IBookService>();

                var result = _bookService.getBook(msg.BookId);

                if (result == null)
                    throw new Exception("Book not found");

               
                var message = new BookServiceResponse(msg)
                {
                    BookQuantity = new BookQuantity
                    {
                        Id = result.Id,
                        Quantity = result.Quantity,
                    }
                };

                return message;
            }
        }
    }
}
