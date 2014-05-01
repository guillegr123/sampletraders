using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SampleTraders.Data
{
    public class RepositoryMongoBase<TModel> where TModel : class
    {
        protected readonly IMongoDBDatabaseFactory DbFactory;
        private readonly string DataCollectionName;

        private MongoDatabase _Db = null;
        protected MongoDatabase Db
        {
            get
            {
                if (_Db == null)
                {
                    _Db = DbFactory.GetDatabase();
                }
                return _Db;
            }
        }

        protected MongoCollection<TModel> DataCollection
        {
            get
            {
                return Db.GetCollection<TModel>(DataCollectionName);
            }
        }

        public RepositoryMongoBase(IMongoDBDatabaseFactory dbFactory, string dataCollectionName)
        {
            DbFactory = dbFactory;
            DataCollectionName = dataCollectionName;
        }

        public List<TModel> GetAll()
        {
            return (from e in DataCollection.AsQueryable() select e).ToList();
        }
    }
}