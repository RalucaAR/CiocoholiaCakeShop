using CakeShop.Repositories;
using Ciocoholia.API.Controllers;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ciocoholia.API.Tests
{
    public class FeedbackControllerTest
    {
        [Fact]
        public void SubmitFeedback_ReturnsIActionResult_BadRequest()
        {
            //Arrange
            var feedback = new Feedback();
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Feedback.CreateAsync(feedback));
            var controller = new FeedbackController(mockRepositoryWrapper.Object);
            controller.ModelState.AddModelError("Object", "Empty feedback");

            //Act
            var result = controller.SubmitFeedback(feedback);

            //Assert
            var iactionResult = Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public void SubmitFeedback_ReturnsIActionResult_Success()
        {
            //Arrange
            var feedback = new Feedback
            {
                Id = 1,
                Content = "Feedbak content",
                Email = "mail.com"
                
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Feedback.CreateAsync(feedback))
                .Returns(Task.FromResult(feedback));
            var controller = new FeedbackController(mockRepositoryWrapper.Object);

            //Act
            var result = controller.SubmitFeedback(feedback);

            //Assert
            var iactionResult = Assert.IsType<OkResult>(result.Result);

        }
    }
}
