using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scaffold.Application.Services;
using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Models.ProductModel;
using Scaffold.Domain.Models.ProductModel.Commands;
using Scaffold.Infra.Repositories;
using Scaffold.Domain.Models.ProductModel.Queries;
using System.Collections.Generic;
using Scaffold.Domain.Models.CartModel.Commands;
using Scaffold.Domain.Models.CartModel;
using Amazon;
using Amazon.Runtime;
using Scaffold.Domain.Models.ProductModel.Repositories;
using Scaffold.Domain.Models.CartModel.Repositories;
using Scaffold.Domain.Models.CartModel.Queries;

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

            services.AddSingleton<AmazonDynamoDBClient>(serviceConfiguration =>
            {
                var credentials = new BasicAWSCredentials("AKIAJ6D6BCI7PMF3R6LQ", "cOGmhJEx+9tYxuqOYvZTzuzMYD7+IKzlt0gjuTs9");
                return new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            });

            services.AddScoped<IBus, Bus>();
            services.AddScoped<INotificationHandler, NotificationHandler>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            // Product Commands
            services.AddTransient<ICommandHandler<ProductCreateCommand, Product>, ProductCreateCommandHandler>();

            // Product Queries
            services.AddTransient<IQueryHandler<ProductGetAllQuery, List<Product>>, ProductGetAllQueryHandler>();
            services.AddTransient<IQueryHandler<ProductGetByIdQuery, Product>, ProductGetByIdQueryHandler>();
            services.AddTransient<IQueryHandler<ProductGetBySkuQuery, Product>, ProductGetBySkuQueryHandler>();

            // Cart Commands
            services.AddTransient<ICommandHandler<CartCreateCommand, Cart>, CartCreateCommandHandler>();
            services.AddTransient<ICommandHandler<CartDeleteCommand, Cart>, CartDeleteCommandHandler>();

            // Cart Queries
            services.AddTransient<IQueryHandler<CartGetAllQuery, List<Cart>>, CartGetAllQueryHandler>();
            services.AddTransient<IQueryHandler<CartGetByIdQuery, Cart>, CartGetByIdQueryHandler>();
            services.AddTransient<IQueryHandler<CartGetByCustomerIdQuery, Cart>, CartGetByCustomerIdQueryHandler>();
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
