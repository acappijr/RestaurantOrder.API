using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantOrder.Data;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Test
{
    [TestClass]
    public class InMemoryDataBaseTests
    {
        private DbContextOptionsBuilder<RestaurantOrderContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<RestaurantOrderContext>();
            _builder.UseInMemoryDatabase("Test");
        }

        [TestMethod]
        public void CanInsertDishIntoDatabase()
        {
            using var _context = new RestaurantOrderContext(_builder.Options);
            var dish = new Dish()
            {
                DishName = "Spaghetti Bolognese",
                Price = 9.99M
            };
            _context.Dishes.Add(dish);
            Assert.AreEqual(EntityState.Added, _context.Entry(dish).State);
            _context.SaveChanges();
            Assert.AreEqual(EntityState.Unchanged, _context.Entry(dish).State);
        }

    }

}
