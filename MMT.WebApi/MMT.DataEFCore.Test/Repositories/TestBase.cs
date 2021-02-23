using Microsoft.EntityFrameworkCore;
using MMT.DataEFCore.DBContext;
using NUnit.Framework;

namespace MMT.DataEFCore.Test.Repositories
{
    public class TestBase
    {
        internal DatabaseContext dbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                           .UseInMemoryDatabase(databaseName: "SSE_Test")
                           .Options;
            dbContext = new DatabaseContext(options);
        }

        [TearDown]
        public void Clear()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}