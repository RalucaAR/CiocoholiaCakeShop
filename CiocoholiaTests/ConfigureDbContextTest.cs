using CakeShop.Interfaces;
using CakeShop.IRepositories;
using CakeShop.Repositories;
using Ciocoholia;
using Ciocoholia.API;
using Ciocoholia.IRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CiocoholiaTests
{
    public class ConfigureDbContextTest
    {
        [Fact]
        public void Proper_ConnectionToDB_All_Required_Services()
        {
            // Arrange & Act
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            // Assert
            Assert.NotNull(webHost);
            Assert.NotNull(webHost.Services.GetRequiredService<IRepositoryWrapper>());
            Assert.NotNull(webHost.Services.GetRequiredService<ICakeRepository>());
            Assert.NotNull(webHost.Services.GetRequiredService<ICategoryRepository>());
            Assert.NotNull(webHost.Services.GetRequiredService<IOrderRepository>());
            Assert.NotNull(webHost.Services.GetRequiredService<IOrderDetailRepository>());
            Assert.NotNull(webHost.Services.GetRequiredService<IFeedbackRepository>());
        }
    }
}
