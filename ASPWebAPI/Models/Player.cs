using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASPWebAPI.Models
{
    public class Player
    {
        public ObjectId Id { get; set; }

        [BsonElement("PlayerId")]
        public int PlayerId { get; set; }

        [BsonElement("UserName")]
        public string UserName { get; set; }
    }
}