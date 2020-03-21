using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Repositories;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public FeedbackController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Route("[action]/{feedback}")]
        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(Feedback feedback)
        {
            var x = await _repositoryWrapper.Feedback.CreateAsync(feedback);
            await _repositoryWrapper.SaveAsync();
            if (x != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}