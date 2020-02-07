using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CakeShop.API.ViewModels;
using CakeShop.Models;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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

        [Authorize(Policy = "ManageCakes")]
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
                var cakeObj = JsonConvert.DeserializeObject<AddCakeViewModel>(cake);
                return View(cakeObj);
            }
            else
            {
                return View(null);
            }
        }

        [Authorize(Policy = "ManageCakes")]
        public IActionResult AddCakeAction([FromForm]AddCakeViewModel addCakeViewModel)
        {
            string uniqueFileName = null;
            string filePath = null;
            if (addCakeViewModel.Image != null)
            {
                string uploadsFolder = "/img/";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + addCakeViewModel.Image.FileName;
                filePath = uploadsFolder + uniqueFileName;
                string absoluteFilePah = "F:\\FACULTATE\\AN IV\\Dezvoltarea aplicatiilor WEB\\Proiect\\CiocoholiaCakeShop\\CiocoholiaCakeShop\\wwwroot\\img\\" + uniqueFileName;
                addCakeViewModel.Image.CopyTo(new FileStream(absoluteFilePah, FileMode.Create));
            };


            var cake = new Cake
            {
                Name = addCakeViewModel.Name,
                Description = addCakeViewModel.Description,
                Price = addCakeViewModel.Price,
                Weigth = addCakeViewModel.Weigth,
                ImageUrl = filePath,
                IsCakeOfTheWeek = addCakeViewModel.IsCakeOfTheWeek,
                CategoryId = addCakeViewModel.CategoryId
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/AddCake/" + cake);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(cake);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress,
                new StringContent(json, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {

                return View("Submit");
            }
            else
            {
                return RedirectToAction("AddCake", "Management");
            }
        }

        [Authorize(Policy = "ManageCakes")]
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

        [Authorize(Policy = "ManageCakes")]
        public IActionResult EditCakeAction([FromForm] ManageCakeViewModel manageCakeViewModel)
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

        [Authorize(Policy = "ManageCakes")]
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

        [Authorize(Policy = "ManageOrders")]
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

                var newOrder = new MyOrderViewModel();
                foreach (var orderr in orderObj)
                {
                    orderr.OrderStates = newOrder.OrderStates;
                }
                return View(orderObj);
            }
            else
            {
                return View(null);
            }
        }

        public class OrderTemp
        {
            public string orderState;
        }

        [Authorize(Policy = "ManageOrders")]
        [HttpPost]
        public IActionResult SetOrderState(int id, string orderState)
        {
            var order = new Order
            {
                Id = id,
                OrderState = orderState
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Administration/SetOrderState/" + order);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(order, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress,
                content).Result;

            if (response.IsSuccessStatusCode)
            {
                return View("Submit");
            }
            else
            {
                return RedirectToAction("AllOrders", "Management");
            }
        }
    }
}