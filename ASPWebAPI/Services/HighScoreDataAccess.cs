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

        public IEnumerable<HighScore> GetHighScores()
        {
            return _highScores.Find(new BsonDocument()).ToEnumerable();
        }
    }
}