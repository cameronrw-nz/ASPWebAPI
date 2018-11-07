using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASPWebAPI.Models
{
    public class HighScore
    {
        public ObjectId Id { get; set; }

        [BsonElement("HighScoreId")]
        public int HighScoreId { get; set; }

        [BsonElement("Score")]
        public int Score { get; set; }

        [BsonElement("")]
        public string Player { get; set; }
    }
}