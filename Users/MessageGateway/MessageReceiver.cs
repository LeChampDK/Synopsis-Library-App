using EasyNetQ;
using Global.Messages.Request;
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
                _bus.PubSub.Subscribe<UserServiceReceive>("UserMicroService", msg => ProcessMessage(msg));

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private void ProcessMessage(UserServiceReceive msg)
        {
            using (var scope = _provider.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _userService = service.GetService<IUserService>();
                var _messageProducer = service.GetService<MessageProducer>();

                var result = _userService.GetUser(msg.UserId);

                _messageProducer.UserResponse(result);
            }
        }

    }
}
