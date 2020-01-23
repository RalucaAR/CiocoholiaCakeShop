using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CakeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CiocoholiaCakeShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Cake/CakeDetail/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var CakeDetail = response.Content.ReadAsStringAsync().Result;
                var CakeDetailObj = JsonConvert.DeserializeObject<Cake>(CakeDetail);
                return View(CakeDetailObj);
            }
            else
            {
                return View(null);
            }
        }
    }
}