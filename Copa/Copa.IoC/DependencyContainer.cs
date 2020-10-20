using AppCore.Implementations;
using AppCore.Services;
using Copa.AppCore.Implementations;
using Copa.AppCore.Services;
using Copa.Infrastructure.Services;
using Infrastructure.DataTypes;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration _configuration, bool isDevelopment)
        {
            //Clients
            var currentUrl = _configuration.GetSection("AppUrl").Value;
            services.AddHttpClient("Self", client =>
            {
                client.BaseAddress = new Uri(currentUrl);
                client.Timeout = TimeSpan.FromMinutes(1);
            });

            //Infrastructure
            var equipesUrl = _configuration.GetSection("EquipesUrl").Value;
            services.AddHttpClient("Equipes", client =>
             {
                 client.BaseAddress = new Uri(equipesUrl);
                 client.Timeout = TimeSpan.FromMinutes(1);
             });

            services.AddScoped(typeof(IEF_Repository<>), typeof(EF_Repository<>));
            services.AddScoped<IEquipes_Service, EquipesService>();
            services.AddScoped<ICopa_Service, Copa_Service>();

            //AppCore
            services.AddScoped(typeof(IEF_Service<>), typeof(EF_Service<>));
            
        }
    }
}
