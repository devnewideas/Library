using Library.Models;
using Library.Repositories;

namespace Library.RestApi.UnitTests
{
    public static class MockData
    {
        public static SaveReaderResource GetSaveReaderResource()
        {
            var result = new SaveReaderResource
            {
                Name = "Stefan",
                DOB = new System.DateTime(1982, 10, 01)
            };

            return result;
        }
    }
}
