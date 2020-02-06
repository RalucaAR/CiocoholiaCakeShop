using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CakeShop.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CiocoholiaCakeShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        public OrderController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CheckoutComplete([FromForm]OrderViewModel orderViewModel)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var order = new Order
            {
                AddressLine1 = orderViewModel.AddressLine1,
                City = orderViewModel.City,
                PhoneNumber = orderViewModel.PhoneNumber,
                UserId = user.Id,
                OrderState = "Waiting"
                
            };

            //read cookie from IHttpContextAccessor  
            string cookieValueFromContext = HttpContext.Request.Cookies["CartId-cookie"];

            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            HttpClient client = new HttpClient(handler);

            client.BaseAddress = new Uri("https://localhost:5001/api/Order/CheckoutOrder/" + order);
            cookieContainer.Add(client.BaseAddress, new Cookie("CartId-cookie", cookieValueFromContext));
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(order, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Order");
            }
        }

        public IActionResult MyOrderContent()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Order/MyOrder/" + user.Id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var order = response.Content.ReadAsStringAsync().Result;
                var orderObj = JsonConvert.DeserializeObject<IEnumerable<MyOrderViewModel>>(order);
                return View(orderObj);
            }
            else
            {
                return View(null);
            }
        }


    }
}