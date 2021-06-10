using AutoMapper;
using Library.Models;
using Library.ServiceProcess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.RestApi.UnitTests
{
    public static class MockHelper
    {
        public static Mock<IReaderService> GetReaderServiceMock()
        {
            Mock<IReaderService> mockReaderService = new Mock<IReaderService>();
            mockReaderService.Setup(X => X.ListAsync(
                It.IsAny<ReadersQuery>()
                )).ReturnsAsync(new QueryResult<Reader>
                {
                    Items = new List<Reader>
                  {
                      new Reader
                      {
                          Id = 1,
                          Name = "Stefan",
                          DOB = new DateTime(1982,10,01)
                      },
                      new Reader
                      {
                          Id = 2,
                          Name = "Christopher",
                          DOB = new DateTime(1984,10,01)
                      }
                  }
                });
            mockReaderService.Setup(X => X.SaveAsync(
                It.IsAny<Reader>()
                )).ReturnsAsync(new ReaderResponse (It.IsAny<Reader>())
                { 
                    Success = true,
                    Resource = new Reader
                    {
                        Id = 1,
                        Name = "Stefan",
                        DOB = new DateTime(1982, 10, 01)
                    }
                    
                });
            mockReaderService.Setup(X => X.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<Reader>()
                )).ReturnsAsync(new ReaderResponse(It.IsAny<Reader>())
                {
                    Success = true,
                    Resource = new Reader
                    {
                        Id = 1,
                        Name = "Stefan",
                        DOB = new DateTime(1982, 10, 01)
                    }

                });
            mockReaderService.Setup(X => X.DeleteAsync(
                It.IsAny<int>()
                )).ReturnsAsync(new ReaderResponse(It.IsAny<Reader>())
                {
                    Success = true,
                    Resource = new Reader
                    {
                        Id = 1,
                        Name = "Stefan",
                        DOB = new DateTime(1982, 10, 01)
                    }

                });

            return mockReaderService;
        }

        public static Mock<IMapper> GetMapperMock()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<ReadersQueryResource, ReadersQuery>(It.IsAny<ReadersQueryResource>()))
                .Returns(new ReadersQuery(null, 1, 5)
                {
                    Name = null,
                });
            mockMapper.Setup(x => x.Map<QueryResult<Reader>, QueryResultResource<ReaderResource>>(It.IsAny<QueryResult<Reader>>()))
                .Returns(new QueryResultResource<ReaderResource>()
                {
                    Items = new List<ReaderResource>
                    {
                        new ReaderResource
                        {
                          Id = 1,
                          Name = "Stefan",
                          DOB = new DateTime(1982,10,01)
                        },
                        new ReaderResource
                        {
                          Id = 2,
                          Name = "Christopher",
                          DOB = new DateTime(1984,10,01)
                        }
                    }
                }
                );

            return mockMapper;
        }

        public static Mock<IMapper> PostMapperMock()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<SaveReaderResource, Reader>(It.IsAny<SaveReaderResource>()))
                .Returns(new Reader
                {
                    Name = "Stefan",
                    DOB = new DateTime(1982, 10, 01),
                });
            mockMapper.Setup(x => x.Map<Reader, ReaderResource>(It.IsAny<Reader>()))
                .Returns(new ReaderResource()
                {
                    Id = 1,
                    Name = "Stefan",
                    DOB = new DateTime(1982, 10, 01),
                }
                );

            return mockMapper;
        }
    }
}
