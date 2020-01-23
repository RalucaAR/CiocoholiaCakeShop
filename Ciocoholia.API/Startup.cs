using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CakeShop.Models;
using Ciocoholia;
using Ciocoholia.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Ciocoholia.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.ConfigureDbContext(Configuration, "Ciocoholia.API");
            services.InjectRepositories();

            services.AddControllers().AddNewtonsoftJson(x => 
                        x.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IShoppingCartService>(sp => ShoppingCartService.GetCart(sp));
            services.AddScoped<IOrderService, OrderService>();

            services.AddMemoryCache();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            //// services.AddSession();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ManageOrders",
            //         policy => policy.RequireRole("Admin"));
            //    options.AddPolicy("ManageCakes",
            //        policy => policy.RequireRole("Admin", "Manager"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSession();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
