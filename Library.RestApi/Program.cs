// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi
{
    using Library.Repositories;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// This class is the starting point of this rest service.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// It was necessary to change the Main method to guarantee that our database is going to be “created” 
        /// when the application starts since we’re using an in-memory provider.Without this change, the readers that we want to seed won’t be created.
        /// </summary>
        /// <param name="args">argument array.</param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }

            host.Run();
        }

        /// <summary>
        /// This method is used to create a host builder.
        /// </summary>
        /// <param name="args">argument array.</param>
        /// <returns>builder for web host.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
