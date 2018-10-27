using ASPWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public class ProductsDataAccess : IProductsDataAccess
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Product> _products;

        public ProductsDataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("EmployeeDB");
            _products = _db.GetCollection<Product>("Products");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products.Find(new BsonDocument()).ToEnumerable();
        }

        public void InsertProduct(Product insertedProduct)
        {
            _products.InsertOne(insertedProduct);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var updateStatement = Builders<Product>.Update.Set(o => o.ProductName, updatedProduct.ProductName);
            _products.UpdateOne(product => product.ProductId == updatedProduct.ProductId, updateStatement);
        }

        public void DeleteProduct(int productId)
        {
            _products.DeleteOne(product => product.ProductId == productId);
        }
    }
}