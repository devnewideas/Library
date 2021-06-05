// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.RestApi
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// This class is the starting point of this rest service.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main Method.
        /// </summary>
        /// <param name="args">argument array.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
