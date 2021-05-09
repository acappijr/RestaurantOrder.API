/* 
 * Here I'll place most of comments and assumptions I had.
 * This is an API that implements most of what was required. As far as my concern most of operations are idempotent and have Immutability
 * I have knowledge about caching and ETags to handle concurrency, but I didn't have time to do it
 * I believe I made a good separation of concerns
 * I have only one unit test, I would like to bring all my Postman tests to the tests project but I didn't have time also
 * I made some API designs decisions, like using proper routing, DTOs for creating objects and DTOs for responses different from entities
 * No comments about code readability, except for I did what I could
 * I used dependency injection of dbcontext, dishes and orders repositories
 * I used Async methods whenever it would get benefited, specially accessing database, except in void methods
 * For error handling, in Production environment it will return a 500 status and a custom message, also some validation rules returning status 400
 *
 * The decision of the API design consists in one route for dishes and one for orders. I only implemented the get and post methods for both.
 * When adding a new order the consumer of the API need to supply the full object, and the response brings the address of the new created order in the Location header.
 * With that address in hand the frontend can request it to get the order placed, or request the address/dishes will bring the related dishes.
 * On the project I included an exported file from my Postman requests.
 *
 * OBS* most of files will include an OBS section related to the file
 * - Here I ensure the migration of the database
 */

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using RestaurantOrder.Data;

namespace RestaurantOrder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<RestaurantOrderContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
