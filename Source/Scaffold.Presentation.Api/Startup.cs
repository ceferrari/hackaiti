using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scaffold.Application.AppServices;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Models.Product;
using Scaffold.Domain.Models.Product.Commands;
using Scaffold.Domain.Models.Product.Queries;
using System.Collections.Generic;

namespace Scaffold.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<IBus, Bus>();
            services.AddScoped<INotificationHandler, NotificationHandler>();

            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<ICommandHandler<ProductCreateCommand, Product>, ProductCreateCommandHandler>();
            services.AddTransient<IQueryHandler<ProductGetQuery, List<Product>>, ProductGetQueryHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
