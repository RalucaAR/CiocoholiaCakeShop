using CakeShop.Models;
using CakeShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API
{
    public static class DBInitializer
    {
        public static async Task InitializeDatabaseAsync(IRepositoryWrapper repositoryWrapper)
        {
            if (repositoryWrapper.Category.GetAllAsync().Result.Count() == 0 &&
                repositoryWrapper.Cake.GetAllAsync().Result.Count() == 0)
            {
                var cakeCategory = new Category
                {
                    Name = "Cake"
                };

                await repositoryWrapper.Category.CreateAsync(cakeCategory);

                var pieceOfCakeCategory = new Category
                {
                    Name = "PieceOfCake"
                };
                
                await repositoryWrapper.Category.CreateAsync(pieceOfCakeCategory);
                await repositoryWrapper.SaveAsync();

                var regal = new Cake
                {
                    Name = "Regal Cake",
                    Description = "Our special cake will make you love it!",
                    CategoryId = cakeCategory.Id,
                    ImageUrl = "/img/tort-mousse-ciocolata.jpg",
                    IsCakeOfTheWeek = true,
                    Price = 97,
                    Weigth = "1000",
                    Stock = 10
                };

                await repositoryWrapper.Cake.CreateAsync(regal);

                var tiramisu = new Cake
                {
                    Name = "Tiramisu",
                    Description = "Tiramisu is a cool, refreshing Italian dessert that once tasted, leaves an indelible impression on you.",
                    CategoryId = pieceOfCakeCategory.Id,
                    ImageUrl = "/img/prajitura-tiramisu.jpg",
                    IsCakeOfTheWeek = true,
                    Price = 16,
                    Weigth = "120",
                    Stock = 21
                };
                await repositoryWrapper.Cake.CreateAsync(tiramisu);
                await repositoryWrapper.SaveAsync();
            }
        }
    }
}
