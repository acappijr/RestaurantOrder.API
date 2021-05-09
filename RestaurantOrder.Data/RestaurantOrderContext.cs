using System;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Data
{
    public class RestaurantOrderContext : DbContext
    {
        public RestaurantOrderContext(DbContextOptions<RestaurantOrderContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDishes>()
                .HasKey(od => new {od.OrderId, od.DishId});
            
            //todo seeding data
            modelBuilder.Entity<Dish>().HasData(
                new Dish()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cd54f9b95"),
                    DishName = "Lasagne Alla Bolognese",
                    Price = 12.99M,
                    CreationDateTime = new DateTime(2020, 12, 9, 1, 23, 00),
                },
                new Dish()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-1115-b9c2d7680450"),
                    DishName = "Pizza Margherita",
                    Price = 19.99M,
                    CreationDateTime = new DateTime(2020, 12, 9, 1, 25, 00),
                },
                new Dish()
                {
                    Id = Guid.Parse("5b3621c0-7b45-4e80-9c8b-3398cba7ee05"),
                    DishName = "Chiken Parmigiana",
                    Price = 10.99M,
                    CreationDateTime = new DateTime(2020, 12, 9, 1, 25, 00),
                }
                );



            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e40cd54f9bac"),
                    Customer = "Table 1",
                    Price = 10.99M,
                    CreationDateTime = new DateTime(2020, 12, 9, 9, 41, 00),

                },
                new Order()
                {
                    Id = Guid.Parse("d27777e9-2ba9-473a-a40f-e40cd54f9b95"),
                    Customer = "Table 22",
                    Price = 30.98M,
                    CreationDateTime = new DateTime(2020, 12, 9, 9, 41, 00),
                }
            );

            modelBuilder.Entity<OrderDishes>().HasData(
                new OrderDishes
                {
                    OrderId = Guid.Parse("d28888e9-2ba9-473a-a40f-e40cd54f9bac"),
                    DishId = Guid.Parse("5b3621c0-7b45-4e80-9c8b-3398cba7ee05"),
                    Quantity = 1,
                },
                new OrderDishes
                {
                    OrderId = Guid.Parse("d27777e9-2ba9-473a-a40f-e40cd54f9b95"),
                    DishId = Guid.Parse("5b3621c0-7b45-4e80-9c8b-3398cba7ee05"),
                    Quantity = 1,
                },
                new OrderDishes
                {
                    OrderId = Guid.Parse("d27777e9-2ba9-473a-a40f-e40cd54f9b95"),
                    DishId = Guid.Parse("2902b665-1190-4c70-1115-b9c2d7680450"),
                    Quantity = 2,
                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
