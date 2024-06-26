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

        public async Task UpdateMongoDB(User user)
        {
            // update user in mongodb
            var filter = Builders<User>.Filter.Eq("Id", user.UserId);
            var update = Builders<User>.Update
                .Set("FirstName", user.FirstName)
                .Set("LastName", user.LastName)
                .Set("Email", user.Email)
                .Set("PhoneNumber", user.PhoneNumber)
                .Set("Address", user.Address);
            await Users.UpdateOneAsync(filter, update);
        }

        public async Task AddMongoDB(User user)
        {
            // add user in mongodb
            await Users.InsertOneAsync(user);
        }
    }
}
