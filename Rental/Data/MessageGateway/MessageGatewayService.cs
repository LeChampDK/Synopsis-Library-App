using EasyNetQ;
using Global.Messages.Request;
using Global.Messages.Response;
using System.Threading.Tasks;

namespace Rental.Data.MessageGateway
{
    public class MessageGatewayService
    {
        private readonly IBus bus;

        public MessageGatewayService(IBus bus)
        {
            this.bus = bus;
        }

        public async Task Run()
        {
            
        }
    }
}
