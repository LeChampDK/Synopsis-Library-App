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
                _bus.Rpc.Respond<UserServiceReceive, UserServiceResponse>(msg => ProcessMessage(msg));

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private UserServiceResponse ProcessMessage(UserServiceReceive msg)
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

    }
}
