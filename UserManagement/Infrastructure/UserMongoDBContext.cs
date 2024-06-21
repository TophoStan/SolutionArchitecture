using UserManagement.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace UserManagement.Infrastructure
{
    public class UserMongoDBContext
    {
        private readonly IMongoDatabase _database;
        private readonly UserMySQLContext _sqlContext;

        public UserMongoDBContext(IMongoDatabase database, UserMySQLContext sqlContext)
        {
            _database = database;
            _sqlContext = sqlContext;
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

        public async Task SQLToMongoDB()
        {
            Console.WriteLine("Migrating support data from SQL to MongoDB");
            // Retrieve data from SQL database
            List<User> sqlUsers = await _sqlContext.Users.ToListAsync();

            // Insert data into MongoDB
            if (sqlUsers.Any())
            {
                await Users.InsertManyAsync(sqlUsers);
            }
        }
    }
}
