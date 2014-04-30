using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.Data
{
    public class MongoDatabaseFactory : IMongoDBDatabaseFactory
    {
        private readonly string ConnectionString;
        private readonly string DBName;

        public MongoDatabaseFactory(string connectionString)
        {
            ConnectionString = connectionString;
            DBName = MongoUrl.Create(connectionString).DatabaseName;
        }

        public MongoDatabase GetDatabase()
        {
            var mc = new MongoClient(ConnectionString);
            return mc.GetServer().GetDatabase(DBName);
        }
    }
}