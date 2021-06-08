using Library.Models;
using Library.RestApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.Api.IntegrationTests
{
    public class LibraryTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public LibraryTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetAllReadersAsync()
        {
            // Arrange
            var request = "/api/readers";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();
            var readers = JsonConvert.DeserializeObject<QueryResultResource<ReaderResource>>(stringResponse);
            Assert.Contains(readers.Items, p => p.Name == "John");
        }

        [Fact]
        public async Task TestGetAllBooksAsync()
        {
            // Arrange
            var request = "/api/books";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<QueryResultResource<BookResource>>(stringResponse);
            Assert.Contains(books.Items, p => p.ISBN == "1001");
        }

        [Fact]
        public async Task TestGetReaderByNameAsync()
        {
            // Arrange
            var request = "/api/readers?name=John";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();
            var readers = JsonConvert.DeserializeObject<QueryResultResource<ReaderResource>>(stringResponse);
            Assert.Contains(readers.Items, p => p.Name == "John");
        }

        [Fact]
        public async Task TestPutLostBookFlagValueAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/books/13",
                Body = new
                {
                    Title = "C# Programming",
                    ISBN = "1004",
                    ReaderId = 11,
                    Lost = true
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutCheckOutDateValueAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/books/13",
                Body = new
                {
                    Title = "C# Programming",
                    ISBN = "1004",
                    CheckOutDate = new DateTime(2021,06,08,20,55,00),
                    ReaderId = 11,
                    Lost = true
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
