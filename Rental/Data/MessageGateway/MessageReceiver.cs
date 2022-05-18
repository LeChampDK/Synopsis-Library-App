using EasyNetQ;
using Global.Messages.Response;
using Microsoft.Extensions.DependencyInjection;
using Rental.Service.Facade;
using System;
using System.Threading;

namespace Rental.Data.MessageGateway
{
    public class MessageReceiver
    {
        IServiceProvider _provider;
        string _connectionString;
        IBus _bus;

        public MessageReceiver(IServiceProvider provider, string connectionString)
        {
            _provider = provider;
            _connectionString = connectionString;
        }

        public void Start()
        {
            using (_bus = RabbitHutch.CreateBus(_connectionString))
            {
                _bus.PubSub.Subscribe<BookServiceResponse>("RentalMicroServiceBook", msg => ProcessMessage(msg));

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private void ProcessMessage(BookServiceResponse msg)
        {
            using (var scope = _provider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _rentalService = service.GetService<IRentalService>();
                var _messageProducer = service.GetService<MessageProducer>();

                var result = _rentalService.GetAllRentalStatusOnBook(msg.BookQuantity.Id);

                var RentedOut = 0;

                foreach(var item in result)
                {
                    if (item.Rented)
                        RentedOut++;
                }

                

                    


            }
        }
    }
}
