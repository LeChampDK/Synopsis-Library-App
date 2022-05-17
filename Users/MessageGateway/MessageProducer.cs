using EasyNetQ;
using Global.Messages.Response;
using Users.Models;

namespace Users.MessageGateway
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

        internal void UserResponse(User result)
        {
            if (result != null)
            {
                var message = new UserServiceResponse
                {
                    UserId = result.Id,
                    UserExist = true,
                };

                bus.PubSub.Publish(message);
            }
            else {
                var message = new UserDoesNotExistReponse
                {
                   UserDoesNotExist = true
                };

                bus.PubSub.Publish(message);
            }

           
        }
    }
}
