using SampleTraders.Model;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Linq;

namespace SampleTraders.Data
{
    public class RepositoryVendorMongo : RepositoryMongoBase<VendorModel>, IRepositoryVendor
    {
        public RepositoryVendorMongo(IMongoDBDatabaseFactory dbFactory)
            : base(dbFactory, "vendors")
        {
            // Populating vendors, if there are none
            if (DataCollection.Count() == 0)
            {
                DataCollection.Insert(new VendorModel
                {
                    Name = "Lorem Ipsum Intl."
                });
                DataCollection.Insert(new VendorModel
                {
                    Name = "Good ol' Wines"
                });
                DataCollection.Insert(new VendorModel
                {
                    Name = "Juan Perez & Co."
                });
                DataCollection.Insert(new VendorModel
                {
                    Name = "Family Goodies"
                });
                DataCollection.Insert(new VendorModel
                {
                    Name = "Artem Intl."
                });
                DataCollection.Insert(new VendorModel
                {
                    Name = "Alaskan Dairy Products"
                });
            }
        }

        public VendorModel GetById(string id)
        {
            return DataCollection.AsQueryable().Single(x => x.VendorId == ObjectId.Parse(id));
        }
    }
}