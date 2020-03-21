using CakeShop.API.ViewModels;
using CakeShop.Models;
using Ciocoholia.API.Controllers;
using Ciocoholia.API.Services;
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
    public class OrderControllerTest
    {
        [Fact]
        public void Checkout_ReturnsIEnumerableShoppingCartItems_Success()
        {
            // Arrange
            var shoppingCartItems = new List<ShoppingCartItems>
            {
                new ShoppingCartItems
                {
                    CakeId = 1,
                    CakeName = "Chocolate Cake",
                    CakeDescription = "Best Cake",
                    CakeIsCakeOfTheWeek = true,
                    CakePrice = 10,
                    ItemPrice = 14
                }
            };
            var mockShoppingCart = new Mock<IShoppingCartService>();
            mockShoppingCart.Setup(service => service.GetShoppingCartItemsAsync())
                .Returns(Task.FromResult<IEnumerable<ShoppingCartItems>>(shoppingCartItems));
            var mockOrder = new Mock<IOrderService>();
            var controller = new OrderController(mockShoppingCart.Object, mockOrder.Object);

            //Act
            var result = controller.Checkout();

            //Assert
            var iActionResult = Assert.IsAssignableFrom<IEnumerable<ShoppingCartItems>>(result.Result);
            Assert.NotNull(result.Result);
            Assert.Single(result.Result);
            Assert.Equal(shoppingCartItems, result.Result);
        }

        [Fact]
        public void CheckoutOrder_ReturnsNoContent_Problem()
        {
            // Arrange
            var shoppingCartItems = new List<ShoppingCartItems>
            {
                new ShoppingCartItems
                {
                    CakeId = 1,
                    CakeName = "Chocolate Cake",
                    CakeDescription = "Best Cake",
                    CakeIsCakeOfTheWeek = true,
                    CakePrice = 10,
                    ItemPrice = 14
                }
            };
            var order = new Order
            {
                Id = 1,
                City = "Bucharest",
                OrderState = "Delivering",
                OrderTotal = 200,
                PhoneNumber = "098738273"
            };
            var mockShoppingCart = new Mock<IShoppingCartService>();
            mockShoppingCart.Setup(service => service.GetShoppingCartItemsAsync());
            var mockOrder = new Mock<IOrderService>();
            var controller = new OrderController(mockShoppingCart.Object, mockOrder.Object);
            controller.ModelState.AddModelError("Address", "Required");

            //Act
            var result = controller.CheckoutOrder(order);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<NoContentResult>(result.Result);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void CheckoutOrder_ReturnsIActionResult_Success()
        {
            // Arrange
            var shoppingCartItems = new List<ShoppingCartItems>
            {
                new ShoppingCartItems
                {
                    CakeId = 1,
                    CakeName = "Chocolate Cake",
                    CakeDescription = "Best Cake",
                    CakeIsCakeOfTheWeek = true,
                    CakePrice = 10,
                    ItemPrice = 14
                }
            };
            var order = new Order
            {
                Id = 1,
                City = "Bucharest",
                OrderState = "Delivering",
                OrderTotal = 200,
                PhoneNumber = "098738273"
            };
            var mockShoppingCart = new Mock<IShoppingCartService>();
            mockShoppingCart.Setup(service => service.GetShoppingCartItemsAsync())
                .Returns(Task.FromResult<IEnumerable<ShoppingCartItems>>(shoppingCartItems));
            var mockOrder = new Mock<IOrderService>();
            mockOrder.Setup(service => service.CreateOrderAsync(order)).
                Returns(Task.FromResult(order));
            mockShoppingCart.Setup(service => service.ClearCartAsync());
            var controller = new OrderController(mockShoppingCart.Object, mockOrder.Object);

            //Act
            var result = controller.CheckoutOrder(order);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<OkResult>(result.Result);
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void MyOrder_ReturnsIEnumerableMyOrderViewModel_Success()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                City = "Bucharest",
                OrderState = "Delivering",
                OrderTotal = 200,
                PhoneNumber = "098738273",
                UserId = "1"
            };
            var myOrder = new List<MyOrderViewModel>
            {
                new MyOrderViewModel
                {
                    Id = 1,
                    OrderTotal = 100,
                    OrderState = "Waiting"
                }
            };
            var mockShoppingCart = new Mock<IShoppingCartService>();
            var mockOrder = new Mock<IOrderService>();
            mockOrder.Setup(service => service.GetAllOrdersAsync(order.UserId)).
                Returns(Task.FromResult<IEnumerable<MyOrderViewModel>>(myOrder));
            var controller = new OrderController(mockShoppingCart.Object, mockOrder.Object);

            //Act
            var result = controller.MyOrder(order.UserId);

            //Assert
            var iActionResult = Assert.IsAssignableFrom<IEnumerable<MyOrderViewModel>>(result.Result);
            Assert.NotNull(result.Result);
            Assert.NotNull(iActionResult);
        }
    }
}
