using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.Model
{
    public class VendorModel
    {
        [BsonId]
        public ObjectId VendorId { set; get; }
        public string Name { set; get; }
    }
}