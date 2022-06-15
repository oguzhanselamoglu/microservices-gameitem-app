using Game.Ordering.Application.Contracts;
using Game.Ordering.Infrastructure.Persistence;
using Game.Ordering.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Game.Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<TodoContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("TodoConnectionString")));

            services.AddDbContext<GameStoreContext>(options => options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));


            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
