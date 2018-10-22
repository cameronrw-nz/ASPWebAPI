using ASPWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public class CustomersDataAccess
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Customer> _customers;

        public CustomersDataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("EmployeeDB");
            _customers = _db.GetCollection<Customer>("Customers");
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers.Find(new BsonDocument()).ToEnumerable();
        }

        public void InsertCustomer(Customer insertedCustomer)
        {
            _customers.InsertOne(insertedCustomer);
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            var updateStatement = Builders<Customer>.Update.Set(o => o.CustomerName, updatedCustomer.CustomerName);
            _customers.UpdateOne(customer => customer.CustomerId == updatedCustomer.CustomerId, updateStatement);
        }

        public void DeleteCustomer(int customerId)
        {
            _customers.DeleteOne(customer => customer.CustomerId == customerId);
        }
    }
}