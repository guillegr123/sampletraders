using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using SampleTraders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.Data
{
    public class RepositoryProductMongo : RepositoryMongoBase<ProductModel>, IRepositoryProduct
    {
        public RepositoryProductMongo(IMongoDBDatabaseFactory dbFactory)
            : base(dbFactory, "products")
        {
        }

        public ProductModel GetById(string id)
        {
            return DataCollection.AsQueryable().Single(x => x.ProductId == ObjectId.Parse(id));
        }

        public void Save(ProductModel product)
        {
            DataCollection.Insert(product);
        }

        public void Update(ProductModel product)
        {
            DataCollection.Update(Query.EQ("_id", product.ProductId), MongoDB.Driver.Builders.Update.Replace<ProductModel>(product));
        }

        public void DeleteById(string id)
        {
            DataCollection.Remove(Query.EQ("_id", ObjectId.Parse(id)));
        }
    }
}