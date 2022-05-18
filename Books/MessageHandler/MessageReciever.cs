using Books.Models;
using Books.Service.Facade;
using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
using Global.Models;
using Global.Models.DTO;
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
                _bus.Rpc.Respond<BookServiceRequest, BookServiceResponse>(msg => ProcessMessage(msg));
                _bus.Rpc.Respond<BookDetailsRequest, BookDetailsResponse>(msg => GetBookDetails(msg));

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private BookServiceResponse ProcessMessage(BookServiceRequest msg)
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

        private BookDetailsResponse GetBookDetails(BookDetailsRequest msg)
        {
            using (var scope = _provider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _bookService = service.GetService<IBookService>();

                var result = _bookService.getBook(msg.BookId);

                if (result == null)
                    throw new Exception("Book not found");

                var message = new BookDetailsResponse(msg)
                {
                    BookDetails = new BookDetailsDTO
                    {
                        Author = result.Author,
                        Title = result.Title,
                    }
                };

                return message;
            }
        }
    }
}
