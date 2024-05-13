using Microsoft.EntityFrameworkCore;
using Samurai.Repo.Data;
using Samurai.Repo.Models;
using Samurai.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Test.Repositories
{
    public class CoffeeRepositoryTest
    {
        DbContextOptions<DataContext> options;
        DataContext _context;
        public CoffeeRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "OurDummyDatabase")
                .Options;

            _context = new DataContext(options);

            _context.Database.EnsureDeleted(); // deletes database, maybe this is not needed.

            // populate database with _context.add method.


            List<Coffee> coffees = [
                new Coffee { Name = "test1", CoffeeTastes = null },
                new Coffee { Name = "test2", CoffeeTastes = null },
                new Coffee { Name = "test3", CoffeeTastes = null },
                new Coffee { Name = "test4", CoffeeTastes = null },
                ];

            _context.Coffees.AddRange(coffees);

            _context.SaveChanges();
     
        }

        [Fact]
        public async Task GetAllCoffee_ShouldReturnAListOfCoffee_WhenCoffeeExistAsync()
        {
            // Arrange - Setup variables

            CoffeeRepository repo = new(_context);
            var expected = 4;

            // Act - Recieve Data / Modify Data
            var dataTask = repo.GetAll();
            var data = await dataTask;
            // Assert - Verify Data

            Assert.Equal(expected, data.Count);
        }

        [Fact]
        public async void GetCoffeeByName_ShouldReturnACoffee_WhenCoffeeExistAsync()
        {
            // Arrange
            CoffeeRepository repo = new(_context);
            string name = "test1";

            // Act
            var data = await repo.GetByName(name);

            // Assert
            Assert.Equal(name, data.Name);
        }

        [Fact]
        public async void GetCoffeeByName_ShouldReturnNull()
        {
            // Arrange
            CoffeeRepository repo = new(_context);
            string name = "test";

            // Act
            var data = await repo.GetByName(name);

            // Assert
            Assert.Null(data);

        }
        



    }
}
