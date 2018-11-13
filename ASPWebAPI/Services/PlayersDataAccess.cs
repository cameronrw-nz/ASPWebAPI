using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ASPWebAPI.Services
{
    public class PlayersDataAccess : IPlayersDataAccess
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Player> _players;

        public PlayersDataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("TicTacToe");
            _players = _db.GetCollection<Player>("Players");
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _players?.Find(new BsonDocument()).ToEnumerable();
        }

        public Player GetPlayer(string userName)
        {
            return _players?.Find(player => player.UserName == userName)?.SingleOrDefault();
        }

        // TODO Insert with new PlayerId
        public void InsertPlayer(Player insertedPlayer)
        {
            _players?.InsertOne(insertedPlayer);
        }

        public void UpdatePlayer(Player updatedPlayer)
        {
            // TODO Updating a player information is not required yet
            throw new NotImplementedException();
        }

        public void DeletePlayer(string userName)
        {
            _players.DeleteOne(player => player.UserName == userName);
            throw new NotImplementedException();
        }
    }
}