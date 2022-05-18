using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Users.Service.Facade;

namespace Users.MessageGateway
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
                _bus.Rpc.Respond<UserServiceRequest, UserServiceResponse>(msg => ProcessMessage(msg));
                _bus.PubSub.Subscribe<ReservationNotificationRequest>("ReservationNotice", SendNofiticationToUser);

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private UserServiceResponse ProcessMessage(UserServiceRequest msg)
        {
            using (var scope = _provider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _userService = service.GetService<IUserService>();

                var result = _userService.GetUser(msg.UserId);

                if (result != null)
                {
                    var message = new UserServiceResponse(msg)
                    {
                        UserId = result.Id,
                        UserExist = true,
                    };

                    return message;
                }
                else
                {
                    var message = new UserServiceResponse(msg)
                    {
                        UserId = 0,
                        UserExist = false,
                    };

                    return message;
                }
            }
        }

        private void SendNofiticationToUser(ReservationNotificationRequest msg)
        {
            Console.WriteLine("Vi henter User fra ID i vores message");
            Console.WriteLine("Vi sende en mail til kunden med bogen der er klar til at blive lånt.");
            Console.WriteLine("UserId: " + msg.UserId);
            Console.WriteLine("Book title: " + msg.BookDetails.Title);
            Console.WriteLine("Book author: " + msg.BookDetails.Author);
        }
    }
}
