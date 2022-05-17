using EasyNetQ;
using System;
using System.Threading;

namespace Books.Data.MessageGateway
{
    public class MessageProducer
    {
        IServiceProvider _provider;
        string _connectionString;
        IBus _bus;

        public MessageProducer(IServiceProvider provider, string connectionString)
        {
            _provider = provider;
            _connectionString = connectionString;
        }

        public void Start()
        {
            using (_bus = RabbitHutch.CreateBus(_connectionString))
            {
                

                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }
    }
}
