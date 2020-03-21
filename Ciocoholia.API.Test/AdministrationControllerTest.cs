﻿using CakeShop.API.ViewModels;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.Controllers;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Ciocoholia.API.Tests
{
    public class AdministrationControllerTest
    {
        [Fact]
        public void AllOrders_ReturnsListOrderViewModel_Success()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    City = "Bucharest",
                    OrderTotal = 10
                }
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Order.GetAllAsync())
                .Returns(Task.FromResult(orders));
            var mockUserManager = new Mock<UserManager<IdentityUser>>();
            //mockUserManager.Setup(repo => repo.);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, mockUserManager.Object);

            // Act
            var result = controller.AllOrders();

            // Assert
            var viewResult = Assert.IsType<Task<IEnumerable<MyOrderViewModel>>>(result);

        }

        [Fact]
        public void ManageCakes_ReturnsIEnumerableCake_Success()
        {
            // Arrange
            var cakeList = new List<Cake> {
                new Cake { Id = 1,
                            Name = "Royal Cake",
                           Category = new Category {Id = 1, Name = "CiocolateCake"},
                           Description = "Best cake",
                           ImageUrl = "/img/img1.jpg",
                           IsCakeOfTheWeek = true,
                           Price = 10,
                           Weigth = "12",
                           Stock = 15
                }
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetAllAsync()).Returns(Task.FromResult(cakeList));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            // Act
            var result = controller.ManageCakes();

            // Assert
            var ienumerableResult = Assert.IsType<Task<IEnumerable<Cake>>>(result);
            var model = Assert.IsAssignableFrom<List<Cake>>(
                ienumerableResult.Result);
            Assert.Single(model);
        }

        [Fact]
        public void AddCake_ReturnsAddCakeViewModel_Success()
        {
            // Arrange
            var categoryList = new List<Category> {
                new Category { Id = 1, Name = "VanillaCakes" }
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Category.GetAllAsync()).Returns(Task.FromResult(categoryList));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            // Act
            var result = controller.AddCake();

            // Assert
            var addCakeViewModelResult = Assert.IsType<Task<AddCakeViewModel>>(result);
            Assert.NotNull(addCakeViewModelResult);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void AddCake_ReturnsBadRequest_Problem()
        {
            // Arrange
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);
            controller.ModelState.AddModelError("Name", "Too long");
            var newCake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "CiocolateCake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg",
                IsCakeOfTheWeek = true,
                Price = 10,
                Weigth = "12",
                Stock = 15
            };

            // Act
            var result = controller.AddCake(newCake);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void AddCake_ReturnsIActionResult_Success()
        {
            //Arrange
            var cake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "CiocolateCake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg",
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            //Act
            var result = controller.AddCake(cake);

            //Asseet
            var iactionResult = Assert.IsAssignableFrom<IActionResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iactionResult);
        }

        [Fact]

        public void EditCake_ReturnsManageCakeViewModel_Success()
        {
            var cake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "CiocolateCake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg"
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id));
            mockRepositoryWrapper.Setup(repo => repo.Category.GetAllAsync());
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            //Act
            var result = controller.EditCake(cake.Id);

            //Assert
            var manageCakeViewModelResult = Assert.IsType<ManageCakeViewModel>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(manageCakeViewModelResult);
        }

        [Fact]
        public void EditCake_ReturnsBadRequest_Problem()
        {
            // Arrange
            var newCake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "CiocolateCake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg"
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(newCake.Id));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);
            controller.ModelState.AddModelError("Price", "Required!");
           

            // Act
            var result = controller.EditCake(newCake);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void EditCake_ReturnsIActionResult_Success()
        {
            //Arrange
            var cake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "CiocolateCake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg",
                IsCakeOfTheWeek = true,
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id));
            mockRepositoryWrapper.Setup(repo => repo.Cake.Update(cake));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            //Act
            var result = controller.EditCake(cake);

            //Asseet
            var iactionResult = Assert.IsAssignableFrom<IActionResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iactionResult);

        }

        [Fact]
        public void DeleteCake_ReturnsIActionResult_Success()
        {

            var cake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "CiocolateCake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg",
                IsCakeOfTheWeek = true,
                Price = 10,
                Weigth = "12",
                Stock = 15
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id));
            mockRepositoryWrapper.Setup(repo => repo.Cake.Delete(cake));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            //Act
            var result = controller.DeleteCake(cake.Id);

            //Assert
            var iactionResultResult = Assert.IsType<OkResult>(result.Result);
        }

        [Fact]
        public void SetOrderState_ReturnsBadRequest_Problem()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                PhoneNumber = "098765432",
                City = "Bucharest",
                OrderTotal = 100
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Order.GetByIdAsync(order.Id));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);
            controller.ModelState.AddModelError("Address", "Required!");

            //Act
            var result = controller.SetOrderState(order);

            //Assert
            var badRequestResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void SetOrderState_ReturnsIActionResult_Success()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                PhoneNumber = "098765432",
                City = "Bucharest",
                OrderTotal = 100
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Order.GetByIdAsync(order.Id));
            mockRepositoryWrapper.Setup(repo => repo.Order.Update(order));
            var userStore = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStore.Object, null, null, null, null, null, null, null, null);
            var controller = new AdministrationController(mockRepositoryWrapper.Object, userManager);

            //Act
            var result = controller.SetOrderState(order);

            //Assert
            var iActionResult= Assert.IsAssignableFrom<IActionResult>(result.Result);
            Assert.NotNull(result.Result);
        }
    }
}
