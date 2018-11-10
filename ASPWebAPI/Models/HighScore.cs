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

        [BsonElement("PlayerId")]
        public int PlayerId { get; set; }
    }
}