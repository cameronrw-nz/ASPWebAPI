using System.Collections.Generic;
using ASPWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ASPWebAPI.Services
{
    public class HighScoreDataAccess : IHighScoreDataAccess
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<HighScore> _highScores;

        public HighScoreDataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("TicTacToe");
            _highScores = _db.GetCollection<HighScore>("HighScore");
        }

        public HighScore GetHighScore(string playerUserName)
        {
            return _highScores?.Find(highScore => highScore.PlayerUserName == playerUserName).SingleOrDefault();
        }

        public IEnumerable<HighScore> GetHighScores()
        {
            return _highScores.Find(new BsonDocument()).ToEnumerable();
        }

        // TODO Insert with new HighScore Id
        public void InsertHighScore(HighScore insertedHighScore)
        {
            _highScores.InsertOne(insertedHighScore);
        }

        public void UpdateHighScore(HighScore updatedHighScore)
        {
            var updateStatement = Builders<HighScore>.Update.Set(o => o.Score, updatedHighScore.Score);
            _highScores.UpdateOne(highScore => highScore.Id == updatedHighScore.Id, updateStatement);
        }
    }
}