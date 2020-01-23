using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Models;
using Ciocoholia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ciocoholia.API.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CiocoholiaCakeShop
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
            services.ConfigureDbContext(Configuration, "CiocoholiaCakeShop");

            services.AddControllersWithViews();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RepositoryContext>();

            services.AddScoped<IShoppingCartService>(sp => ShoppingCartService.GetCart(sp));
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                // options.SlidingExpiration = true;
            });
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageOrders",
                     policy => policy.RequireRole("Admin"));
                options.AddPolicy("ManageCakes",
                    policy => policy.RequireRole("Admin", "Manager"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRoles(serviceProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            Task<IdentityResult> roleResult;
            Task<bool> adminExist = roleManager.RoleExistsAsync("Admin");
            adminExist.Wait();
            if (!adminExist.Result)
            {
                var role = new IdentityRole()
                {
                    Name = "Admin"
                };
                roleResult = roleManager.CreateAsync(role);
                roleResult.Wait();


                var adminUser = new IdentityUser()
                {
                    UserName = "Admin",
                    Email = "admin@mail.com"
                };
                string adminPass = "Parola!1";
                Task<IdentityResult> adminCreated = userManager.CreateAsync(adminUser, adminPass);
                adminCreated.Wait();
                if (adminCreated.Result.Succeeded)
                {
                    Task<IdentityResult> result = userManager.AddToRoleAsync(adminUser, "Admin");

                    result.Wait();
                    var security = userManager.UpdateSecurityStampAsync(adminUser);
                    security.Wait();
                }
            }

            Task<bool> managerExist = roleManager.RoleExistsAsync("Manager");
            managerExist.Wait();
            if (!managerExist.Result)
            {
                var role = new IdentityRole()
                {
                    Name = "Manager"
                };
                roleResult = roleManager.CreateAsync(role);
                roleResult.Wait();


                var managerUser = new IdentityUser()
                {
                    UserName = "Manager",
                    Email = "manager@mail.com"
                };
                string managerPass = "Parola!1";
                Task<IdentityResult> managerCreated = userManager.CreateAsync(managerUser, managerPass);
                managerCreated.Wait();
                if (managerCreated.Result.Succeeded)
                {
                    Task<IdentityResult> result = userManager.AddToRoleAsync(managerUser, "Manager");

                    result.Wait();
                    var security = userManager.UpdateSecurityStampAsync(managerUser);
                    security.Wait();
                }
            }


            }


    }
}


