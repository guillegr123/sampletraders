using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleTraders.Model
{
    public class ProductModel
    {
        [BsonId]
        public ObjectId ProductId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public VendorModel Vendor { get; set; }
    }
}