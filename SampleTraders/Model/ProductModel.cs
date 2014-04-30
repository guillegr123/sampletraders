using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SampleTraders.Model
{
    public class ProductModel
    {
        [BsonId]
        [IgnoreDataMember]
        public ObjectId Id { get; set; }
        [BsonIgnore]
        public string Guid
        {
            set
            {
                if (value != null)
                {
                    Id = ObjectId.Parse(value);
                }
                else
                {
                    Id = default(ObjectId);
                }
            }
            get
            {
                return Id.ToString();
            }
        }
        public string Name { get; set; }
        public int Qty { get; set; }
        public string Vendor { get; set; }
    }
}