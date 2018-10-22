using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASPWebAPI.Models
{
    public class Customer
    {
        public ObjectId Id { get; set; }

        [BsonElement("CustomerId")]
        public int CustomerId { get; set; }

        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }
    }
}