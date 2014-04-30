using SampleTraders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}