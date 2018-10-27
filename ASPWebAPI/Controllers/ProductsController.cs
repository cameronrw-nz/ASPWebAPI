using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ASPWebAPI.Models;
using ASPWebAPI.Services;

namespace ASPWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductsDataAccess _dataAccess;

        Product[] products = new Product[]
        {
            new Product { ProductId = 1, ProductName = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { ProductId = 2, ProductName = "Yo-yo", Category = "Toys", Price = 3 },
            new Product { ProductId = 3, ProductName = "Hammer", Category = "Hardware", Price = 16 }
        };

        public ProductsController() : this((ProductsDataAccess)WebApiConfig.UnityContainer.Resolve(typeof(IProductsDataAccess), "", null))
        {
        }

        public ProductsController(IProductsDataAccess productDataAccess)
        {
            _dataAccess = productDataAccess;
        }

        // GET: api/Products
        public IEnumerable<Product> GetAllProducts()
        {
            return _dataAccess.GetProducts();
        }

        // GET: api/product/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/product
        public IHttpActionResult PostProduct([FromBody]Product product)
        {
            try
            {
                _dataAccess.InsertProduct(product);

                return Created(new Uri(Request.RequestUri + product.ProductId.ToString()), product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST: api/product/1
        public IHttpActionResult PutProduct([FromUri] int productId, [FromBody]Product product)
        {
            try
            {
                _dataAccess.UpdateProduct(product);

                return Created(new Uri(Request.RequestUri + product.ProductId.ToString()), product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // Delete api/products/1
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                _dataAccess.DeleteProduct(id);

                return Created(new Uri(Request.RequestUri + id.ToString()), id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}