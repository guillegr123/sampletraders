using MongoDB.Driver;

namespace SampleTraders.Data
{
    public interface IMongoDBDatabaseFactory
    {
        MongoDatabase GetDatabase();
    }
}
