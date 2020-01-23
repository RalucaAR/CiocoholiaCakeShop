using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CiocoholiaCakeShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public FeedbackController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit([FromForm] FeedbackViewModel feedbackViewModel)
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var feedback = new Feedback
            {
                Email = feedbackViewModel.Email,
                Content = feedbackViewModel.Content,
                UserId = user.Id
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/Feedback/SubmitFeedback/" + feedback);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string Json = JsonConvert.SerializeObject(feedback, Formatting.Indented);

            var content = new StringContent(Json, Encoding.UTF8, "application/json");

            var response =  client.PostAsync(client.BaseAddress, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {

                return RedirectToAction("Index", "Feedback");
            }
        }
    }
}