using CakeShop.Repositories;
using Ciocoholia.API.Controllers;
using Ciocoholia.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Xunit;

namespace Ciocoholia.API.Tests
{
    public class CakeControllerTest
    {
        [Fact]
        public void CakeOfTheWeek_ReturnsIEnumerableCake_Success()
        {
            //Arrange
            var newCake = new List<Cake>
            {
                new Cake
                {
                    Id = 1,
                    Name = "Royal Cake",
                    Category = new Category { Id = 1, Name = "CiocolateCake" },
                    Description = "Best cake",
                    ImageUrl = "/img/img1.jpg",
                    IsCakeOfTheWeek = true,
                    Price = 12,
                    Stock = 10,
                    Weigth = "100"
                }
            };
            var cakeState = true;
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetCakeByIsCakeOfTheWeek(cakeState))
            .Returns(Task.FromResult(newCake));
            var controller = new CakeController(mockRepositoryWrapper.Object);

            //Act
            var result = controller.CakeOfTheWeek(cakeState);

            //Assert 
            var ienumerableResult = Assert.IsAssignableFrom<IEnumerable<Cake>>(result.Result);
            Assert.NotNull(result.Result);
            Assert.Single(result.Result);
            Assert.Equal(result.Result.ToString(), newCake.ToString());
        }

        [Fact]
        public void CakeOfTheWeek_ReturnsIEnumerableCake_False()
        {
            //Arrange
            var newCake = new List<Cake>
            {
                new Cake
                {
                    Id = 1,
                    Name = "Royal Cake",
                    Category = new Category { Id = 1, Name = "CiocolateCake" },
                    Description = "Best cake",
                    ImageUrl = "/img/img1.jpg",
                    IsCakeOfTheWeek = true,
                    Price = 12,
                    Stock = 10,
                    Weigth = "100"
                }
            };
            var cakeState = false;
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetCakeByIsCakeOfTheWeek(cakeState));
            var controller = new CakeController(mockRepositoryWrapper.Object);

            //Act
            var result = controller.CakeOfTheWeek(cakeState);

            //Assert 
            Assert.Null(result.Result);
        }

        [Fact]
        public void Category_ReturnsIEnumerableCake_Success()
        {
            //Arrange
            var newCake = new List<Cake>
            {
                new Cake
                {
                    Id = 1,
                    Name = "Royal Cake",
                    Category = new Category { Id = 1, Name = "PieceOfCake" },
                    Description = "Best cake",
                    ImageUrl = "/img/img1.jpg",
                    IsCakeOfTheWeek = true,
                    Price = 12,
                    Stock = 10,
                    Weigth = "100"
                }
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetCakeByCategoryName("PieceOfCake"))
                .Returns(Task.FromResult(newCake));
            var controller = new CakeController(mockRepositoryWrapper.Object);

            //Act
            var result = controller.Category("PieceOfCake");

            //Assert 
            var ienumerableResult = Assert.IsAssignableFrom<IEnumerable<Cake>>(result.Result);
            Assert.Single(ienumerableResult);
            Assert.NotNull(result.Result);
            Assert.Single(result.Result);
        }

        [Fact]
        public void Category_ReturnsIEnumerableCake_False()
        {
            //Arrange
            var newCake = new List<Cake>
            {
                new Cake
                {
                    Id = 1,
                    Name = "Royal Cake",
                    Category = new Category { Id = 1, Name = "CiocolateCake" },
                    Description = "Best cake",
                    ImageUrl = "/img/img1.jpg",
                    IsCakeOfTheWeek = true,
                    Price = 12,
                    Stock = 10,
                    Weigth = "100"
                }
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.CreateAsync(newCake.Find(x => x.Id == 1)));
            var controller = new CakeController(mockRepositoryWrapper.Object);

            //Act
            var result = controller.Category("PieceOfCake");

            //Assert 
            Assert.Null(result.Result);
        }

        [Fact]
        public void CakeDetail_ReturnsCake_Success()
        {
            //Arrange
            var newCake = new Cake
            {
                Id = 1,
                Name = "Royal Cake",
                Category = new Category { Id = 1, Name = "Cake" },
                Description = "Best cake",
                ImageUrl = "/img/img1.jpg",
                IsCakeOfTheWeek = true,
                Price = 12,
                Stock = 10,
                Weigth = "100"
            };
            var mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            mockRepositoryWrapper.Setup(repo => repo.Cake.GetByIdAsync(newCake.Id)).
                Returns(Task.FromResult(newCake));
            var controller = new CakeController(mockRepositoryWrapper.Object);

            //Act
            var result = controller.CakeDetail(newCake.Id);

            //Assert 
            var cakeResult = Assert.IsAssignableFrom<Cake>(result.Result);
            Assert.Equal(newCake, result.Result);
            Assert.NotNull(result.Result);
        }
    }
}
