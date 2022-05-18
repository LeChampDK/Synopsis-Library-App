using EasyNetQ;
using Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rental.Data;
using Rental.Data.Facade;
using Rental.Data.MessageGateway;
using Rental.Service;
using Rental.Service.Facade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Rental
{
    public class Startup
    {
        string cloudAMQPConnectionString = Config.cloudAMQPConnectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // In-memory database:
            services.AddDbContext<RentalContext>(opt => opt.UseInMemoryDatabase("RentalDb"));

            // Register services for dependency injection
            services.AddScoped<IRentalService, RentalService>();

            // Register repositories for dependency injection
            services.AddScoped<IRentalRepository, RentalRepository>();

            // Register database initializer for dependency injection
            services.AddTransient<IDbInitializer, DbInitializer>();

            services.AddSingleton<MessageProducer>(new
                MessageProducer(cloudAMQPConnectionString));

            IBus bus = RabbitHutch.CreateBus(cloudAMQPConnectionString);
            services.AddSingleton(bus);

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Initialize the database
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<RentalContext>();
                var dbInitializer = services.GetService<IDbInitializer>();
                dbInitializer.Initialize(dbContext);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rental v1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Task.Factory.StartNew(() =>
            //    new MessageReceiver(app.ApplicationServices, cloudAMQPConnectionString).Start());
        }
    }
}
