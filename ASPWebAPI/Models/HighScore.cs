using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ASPWebAPI.Models
{
    public class HighScore
    {
        public ObjectId Id { get; set; }

        [BsonElement("Score")]
        public int Score { get; set; }

        [BsonElement("PlayerUserName")]
        public string PlayerUserName { get; set; }

        public Player Player { get; set; }
    }
}