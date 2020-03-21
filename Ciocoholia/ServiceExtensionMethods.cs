using CakeShop.Interfaces;
using CakeShop.IRepositories;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciocoholia.Repositories;

namespace Ciocoholia
{
    public static class ServiceExtensionMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config, string appName, string connectionAttribute)
        {
            string connectionString = config[connectionAttribute];
            services.AddDbContext<RepositoryContext>(c => c.UseSqlServer(connectionString, 
                b => b.MigrationsAssembly(appName)));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ICakeRepository, CakeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        }
    }
}
