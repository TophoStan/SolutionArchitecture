using SupportManagement.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace SupportManagement.Infrastructure
{
    public class SupportMongoDBContext
    {
        private readonly IMongoDatabase _database;
        private readonly SupportMySQLContext _sqlContext;

        public SupportMongoDBContext(IMongoDatabase database, SupportMySQLContext sqlContext)
        {
            _database = database;
            _sqlContext = sqlContext;
        }

        public IMongoCollection<Support> Supports => _database.GetCollection<Support>("Supports");

        public async Task SQLToMongoDB()
        {
            Console.WriteLine("Migrating support data from SQL to MongoDB");
            // Retrieve data from SQL database
            List<Support> sqlSupports = await _sqlContext.Supports.ToListAsync();

            // Insert data into MongoDB
            if (sqlSupports.Any())
            {
                await Supports.InsertManyAsync(sqlSupports);
            }
        }
    }
}
