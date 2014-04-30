using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SampleTraders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.Data
{
    public class RepositoryProductMongo : IRepositoryProduct
    {
        private readonly IMongoDBDatabaseFactory DbFactory;

        private MongoDatabase _Db = null;
        private MongoDatabase Db
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

        private MongoCollection<ProductModel> Products
        {
            get
            {
                return Db.GetCollection<ProductModel>("products");
            }
        }

        public RepositoryProductMongo(IMongoDBDatabaseFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public List<ProductModel> GetAll()
        {
            return Products.FindAll().ToList();
        }

        public ProductModel GetById(string id)
        {
            return Products.FindOneById(ObjectId.Parse(id));
        }

        public void Save(ProductModel product)
        {
            Products.Insert(product);
        }

        public void Update(ProductModel product)
        {
            Products.Update(Query.EQ("_id", product.Id), MongoDB.Driver.Builders.Update.Replace<ProductModel>(product));
        }

        public void DeleteById(string id)
        {
            Products.Remove(Query.EQ("_id", ObjectId.Parse(id)));
        }
    }
}