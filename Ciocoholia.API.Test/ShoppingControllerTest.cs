using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.Controllers;
using Ciocoholia.API.ViewModels;
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
    public class ShoppingControllerTest
    {
        [Fact]
        public void AddToCart_ReturnsNoFound_Problem()
        {
            // Arrange
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
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);
            controller.ModelState.AddModelError("Price", "Required!");

            //Act
            var result = controller.AddToCart(cake.Id);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<NotFoundResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iActionResult);
        }

        [Fact]
        public void AddToCart_ReturnsIActionResult_Success()
        {
            // Arrange
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
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id))
                .Returns(Task.FromResult(cake));
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            mockShoppingCartItemService.Setup(service => service.AddToCartAsync(cake, 1))
                .Returns(Task.FromResult(1));
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);

            //Act
            var result = controller.AddToCart(cake.Id);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<OkResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iActionResult);
        }

        [Fact]
        public void RemoveFromShoppingCart_ReturnsNoFound_Problem()
        {
            // Arrange
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
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);
            controller.ModelState.AddModelError("Price", "Required!");

            //Act
            var result = controller.RemoveFromShoppingCart(cake.Id);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<NotFoundResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iActionResult);
        }

        [Fact]
        public void RemoveFromShoppingCart_ReturnsIActionResult_Success()
        {
            // Arrange
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
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id))
                .Returns(Task.FromResult(cake));
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            mockShoppingCartItemService.Setup(service => service.RemoveFromCartAsync(cake))
                .Returns(Task.FromResult(1));
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);

            //Act
            var result = controller.RemoveFromShoppingCart(cake.Id);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<OkResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iActionResult);
        }

        [Fact]
        public void RemoveAllCart_ReturnsIActionResult_Success()
        {
            // Arrange
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);

            //Act
            var result = controller.RemoveAllCart();

            //Assert
            var iActionResult = Assert.IsAssignableFrom<OkResult>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iActionResult);
        }

        [Fact]
        public void GetCartItems_ReturnsIEnumerableShoppingCartItems_Success()
        {
            // Arrange
            var shoppingCartItems = new List<ShoppingCartItems>
            {
                new ShoppingCartItems
                {
                    CakeId = 1,
                    CakeName  = "Chocolate Cake",
                    CakeDescription = "Best Cake",
                    CakeIsCakeOfTheWeek = false
                }
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            mockShoppingCartItemService.Setup(service => service.GetShoppingCartItemsAsync())
                .Returns(Task.FromResult<IEnumerable<ShoppingCartItems>>(shoppingCartItems));
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);

            //Act
            var result = controller.GetCartItems();

            //Assert
            var ienumerableResult = Assert.IsAssignableFrom<IEnumerable<ShoppingCartItems>>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(ienumerableResult);
        }

        [Fact]
        public void GetCakeById_ReturnsString_Success()
        {
            // Arrange
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
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(cake.Id))
                .Returns(Task.FromResult(cake));
            var mockShoppingCartItemService = new Mock<IShoppingCartService>();
            var controller = new ShoppingController(mockRepositoryWrapper.Object, mockShoppingCartItemService.Object);

            //Act
            var result = controller.GetCakeById(cake.Id);

            //Assert
            var ienumerableResult = Assert.IsAssignableFrom<Cake>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(ienumerableResult);
            Assert.Equal(cake, result.Result);
        }
    }
}
