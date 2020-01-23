﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CakeShop.API.ViewModels;
using CakeShop.Models;
using Ciocoholia.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CiocoholiaCakeShop.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "ManageCakes")]
        public IActionResult ManageCakes()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/ManageCakes");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var cake = response.Content.ReadAsStringAsync().Result;
                var cakeObj = JsonConvert.DeserializeObject<IEnumerable<Cake>>(cake);
                return View(cakeObj);
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult AddCake()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AddCake");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var cake = response.Content.ReadAsStringAsync().Result;
                var cakeObj = JsonConvert.DeserializeObject<ManageCakeViewModel>(cake);
                return View(cakeObj);
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult AddCakeAction([FromForm]ManageCakeViewModel manageCakeViewModel)
        {
            var cake = new Cake
            {
                Name = manageCakeViewModel.Cake.Name,
                Description = manageCakeViewModel.Cake.Description,
                Price = manageCakeViewModel.Cake.Price,
                Weigth = manageCakeViewModel.Cake.Weigth,
                ImageUrl = manageCakeViewModel.Cake.ImageUrl,
                Stock = manageCakeViewModel.Cake.Stock,
                IsCakeOfTheWeek = manageCakeViewModel.Cake.IsCakeOfTheWeek,
                CategoryId = manageCakeViewModel.Cake.CategoryId
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AddCake/" + cake);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(cake);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, 
                new StringContent( json, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                
                return View("Submit");
            }
            else
            {
                return RedirectToAction("AddCake", "Management");
            }
        }

        public IActionResult EditCake(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/administration/EditCake/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var cake = response.Content.ReadAsStringAsync().Result;
                var cakeObj = JsonConvert.DeserializeObject<ManageCakeViewModel>(cake);
                return View(cakeObj);
            }
            else
            {
                return View(null);
            }
        }

        public IActionResult EditCakeAction(int id, [FromForm] ManageCakeViewModel manageCakeViewModel)
        {
            var cake = new Cake
            {
                Id = id,
                Name = manageCakeViewModel.Cake.Name,
                Description = manageCakeViewModel.Cake.Description,
                Price = manageCakeViewModel.Cake.Price,
                Weigth = manageCakeViewModel.Cake.Weigth,
                ImageUrl = manageCakeViewModel.Cake.ImageUrl,
                Stock = manageCakeViewModel.Cake.Stock,
                IsCakeOfTheWeek = manageCakeViewModel.Cake.IsCakeOfTheWeek,
                CategoryId = manageCakeViewModel.Cake.CategoryId
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/EditCake/" + cake);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(cake);
            HttpResponseMessage response = client.PutAsync(client.BaseAddress,
                new StringContent(json, Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return View("Submit");
            }
            else
            {
                return RedirectToAction("EditCake", "Management");
            }
        }

        
        public IActionResult DeleteCake(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/DeleteCake/" + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                return View("Submit");
            }
            else
            {
                return RedirectToAction("EditCake", "Management");
            }
        }

        public IActionResult AllOrders()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AllOrders");

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