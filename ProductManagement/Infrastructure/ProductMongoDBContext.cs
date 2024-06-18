using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProductManagement.Domain;

namespace ProductManagement.Infrastructure;

public class ProductMongoDBContext : DbContext
{
    private readonly IMongoDatabase _database;
    private readonly ProductMySQLContext _sqlContext;

    public ProductMongoDBContext(IMongoDatabase database, ProductMySQLContext productContext)
    {
        _database = database;
        _sqlContext = productContext;
    }

    public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");


    //TODO implement to SQL

}
