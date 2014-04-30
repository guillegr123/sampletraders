using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            return DataCollection.FindAll().ToList();
        }



        public TModel GetById(string id)
        {
            return DataCollection.FindOneById(ObjectId.Parse(id));
        }
    }
}