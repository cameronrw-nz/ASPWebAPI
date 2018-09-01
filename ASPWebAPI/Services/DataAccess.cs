using ASPWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public class DataAccess
    {
        private MongoClient _client;
        private IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("EmployeeDB");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("Products").Find(new BsonDocument()).ToEnumerable();
        }
    }
}