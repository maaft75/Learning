using MongoDB.Driver;
using bookApi.Models;
using Microsoft.Extensions.Options;

namespace bookApi.Data
{
    public class MongoContext
    {
        private readonly IMongoClient _mongoClient;       
        private readonly IMongoDatabase _mongoDatabase;

        public MongoContext(IOptions<MongoDbContext> mongoDbContext)
        {
            _mongoClient = new MongoClient(mongoDbContext.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(mongoDbContext.Value.DatabaseName);  
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDatabase.GetCollection<T>(name);
        }
    }
}