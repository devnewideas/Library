using Library.Models;
using Library.Repositories;

namespace Library.RestApi.UnitTests
{
    public static class MockData
    {
        public static void Seed(this AppDbContext dbContext)
        {

            dbContext.Readers.Add(new Reader 
            {
                Id = 12,
                Name = "Stefan",
                DOB = new System.DateTime(1981, 01, 21, 12, 02, 00)
            });

            dbContext.Readers.Add(new Reader
            {
                Id = 13,
                Name = "Joakim",
                DOB = new System.DateTime(1982, 01, 21, 12, 02, 00)
            });

            //dbContext.Books.Add(new Book
            //{
            //    Id = 13,
            //    Title = "Python Programming",
            //    ISBN = "1005",
            //    CheckOutDate = new System.DateTime(2021, 04, 21, 08, 30, 10),
            //    ReaderId = 12,
            //    Lost = false

            //});

            //dbContext.Books.Add(new Book
            //{
            //    Id = 13,
            //    Title = "DBMS",
            //    ISBN = "1006",
            //    CheckOutDate = new System.DateTime(2021, 02, 21, 08, 30, 10),
            //    ReaderId = 13,
            //    Lost = false

            //});
        }
    }
}
