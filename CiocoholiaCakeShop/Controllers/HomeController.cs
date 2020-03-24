using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CiocoholiaCakeShop.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using CakeShop.Models;
using Newtonsoft.Json;
using Ciocoholia.Models;

namespace CiocoholiaCakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cakeOfTheWeek = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Cake/CakeOfTheWeek/" + cakeOfTheWeek);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var cake = response.Content.ReadAsStringAsync().Result;
                var cakeObj = JsonConvert.DeserializeObject<IEnumerable<Cake>>(cake);
                return View(cakeObj);             
            } else
            {
                return View(null);
            }            
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
