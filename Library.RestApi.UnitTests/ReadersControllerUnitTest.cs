using AutoMapper;
using Library.Models;
using Library.RestApi.Controllers;
using Library.ServiceProcess;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Library.RestApi.UnitTests
{
    public class ReadersControllerUnitTest
    {
        [Fact]
        public async Task TestGetReaderItemsAsync()
        {
            // Arrange
            Mock<IReaderService> mockReaders = MockHelper.GetReaderServiceMock();
            Mock<IMapper> mockMapper = MockHelper.GetMapperMock();
            
            var readersQuery = new ReadersQueryResource();

            var controller = new ReadersController(mockReaders.Object, mockMapper.Object);

            // Act
            var response = await controller.GetAllAsync(readersQuery);

            var value = response.Items.Count;

            // Assert
            Assert.Equal(2, value);
        }

        [Fact]
        public async Task TestPostReaderItemsAsync()
        {
            // Arrange
            Mock<IReaderService> mockReaders = MockHelper.GetReaderServiceMock();
            Mock<IMapper> mockMapper = MockHelper.PostMapperMock();

            var controller = new ReadersController(mockReaders.Object, mockMapper.Object);

            // Act
            var response = await controller.PostAsync(MockData.GetSaveReaderResource());
            var result = response as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task TestPutReaderItemsAsync()
        {
            // Arrange
            Mock<IReaderService> mockReaders = MockHelper.GetReaderServiceMock();
            Mock<IMapper> mockMapper = MockHelper.PostMapperMock();

            var controller = new ReadersController(mockReaders.Object, mockMapper.Object);

            // Act
            var response = await controller.PutAsync(1,MockData.GetSaveReaderResource());
            var result = response as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task TestDeleteReaderItemsAsync()
        {
            // Arrange
            Mock<IReaderService> mockReaders = MockHelper.GetReaderServiceMock();
            Mock<IMapper> mockMapper = MockHelper.PostMapperMock();

            var controller = new ReadersController(mockReaders.Object, mockMapper.Object);

            // Act
            var response = await controller.DeleteAsync(1);
            var result = response as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
