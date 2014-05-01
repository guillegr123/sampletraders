using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleTraders.Model
{
    public class VendorModel
    {
        [BsonId]
        public ObjectId VendorId { set; get; }
        public string Name { set; get; }
    }
}