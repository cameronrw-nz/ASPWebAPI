using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ASPWebAPI.Models;
using ASPWebAPI.Services;

namespace ASPWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private DataAccess _db;

        Product[] products = new Product[]
        {
            new Product { ProductId = 1, ProductName = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { ProductId = 2, ProductName = "Yo-yo", Category = "Toys", Price = 3 },
            new Product { ProductId = 3, ProductName = "Hammer", Category = "Hardware", Price = 16 }
        };

        public ProductsController()
        {
            _db = new DataAccess();
        }

        // GET: api/Products
        public IEnumerable<Product> GetAllProducts()
        {
            return _db.GetProducts();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}