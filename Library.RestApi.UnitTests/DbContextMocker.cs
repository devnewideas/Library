using Library.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.RestApi.UnitTests
{
    public static class DbContextMocker
    {
        public static AppDbContext GetLibraryDbContextMock(string dbName)
        {
            try
            {
                // Create options for DbContext instance
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: dbName)
                    .Options;

                // Create instance of DbContext
                var dbContext = new AppDbContext(options);

                // Add entities in memory
                dbContext.Seed();

                return dbContext;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
