using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rental.Data.MessageGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            try
            {
                MainAsync().Wait();
                Environment.Exit(0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        static async Task MainAsync()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            try
            {
                await serviceProvider.GetService<MessageGatewayService>().Run();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
