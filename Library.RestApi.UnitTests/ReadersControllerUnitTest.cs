using AutoMapper;
using Library.Models;
using Library.RestApi.Controllers;
using Library.ServiceProcess;
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
    }
}
