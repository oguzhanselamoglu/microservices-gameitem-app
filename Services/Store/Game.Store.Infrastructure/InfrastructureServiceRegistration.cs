using Game.Store.Application.Contracts;
using Game.Store.Infrastructure.Persistence;
using Game.Store.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Game.Store.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<TodoContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("TodoConnectionString")));

            services.AddDbContext<GameStoreContext>(options => options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));


            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IStoreRepository, StoreRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
